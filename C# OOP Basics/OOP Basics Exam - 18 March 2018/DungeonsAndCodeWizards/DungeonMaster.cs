using System;
using System.Linq;
using System.Collections.Generic;

using DungeonsAndCodeWizards.Charaters;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models;
using DungeonsAndCodeWizards.Contracts;

namespace DungeonsAndCodeWizards
{
    public class DungeonMaster
    {
        int lastSurvivorRounds = 0;

        readonly List<Character> charaters = new List<Character>();
        readonly Stack<Item> items = new Stack<Item>();

        CharacterFactory characterFactory = new CharacterFactory();
        ItemFactory itemFactory = new ItemFactory();

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string type = args[1];
            string name = args[2];
            Character character = characterFactory.CreateCharacter(faction, type, name);
            charaters.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string name = args[0];
            Item item = itemFactory.CreateItem(name);
            items.Push(item);

            return $"{name} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = charaters.FirstOrDefault(c => c.Name == characterName);

            Validator.EnsureCharacterIsNotNull(character, characterName);
            Validator.EnsuceItemsIsNotEmpty(items);

            Item item = items.Pop();
            character.ReceiveItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = charaters.FirstOrDefault(c => c.Name == characterName);

            Validator.EnsureCharacterIsNotNull(character, characterName);

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = charaters.FirstOrDefault(c => c.Name == giverName);
            Character receiver = charaters.FirstOrDefault(c => c.Name == receiverName);

            Validator.EnsureCharacterIsNotNull(giver, giverName);
            Validator.EnsureCharacterIsNotNull(receiver, receiverName);

            Item itemToUse = giver.Bag.GetItem(itemName);
            giver.UseItemOn(itemToUse, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = charaters.FirstOrDefault(c => c.Name == giverName);
            Character receiver = charaters.FirstOrDefault(c => c.Name == receiverName);

            Validator.EnsureCharacterIsNotNull(giver, giverName);
            Validator.EnsureCharacterIsNotNull(receiver, receiverName);

            Item item = giver.Bag.GetItem(itemName);
            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            string output = "";

            foreach (Character character in charaters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                output += character.ToString() + Environment.NewLine;
            }

            output = output.TrimEnd(Environment.NewLine.ToCharArray());

            return output;
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = charaters.FirstOrDefault(c => c.Name == attackerName);
            Character receiver = charaters.FirstOrDefault(c => c.Name == receiverName);

            Validator.EnsureCharacterIsNotNull(attacker, attackerName);
            Validator.EnsureCharacterIsNotNull(receiver, receiverName);

            if (attacker is IAttackable == false)
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            Warrior warrior = (Warrior)attacker;
            warrior.Attack(receiver);

            string output = "";

            output += $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (receiver.IsAlive == false)
            {
                output += Environment.NewLine + $"{receiverName} is dead!";
            }

            return output;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = charaters.FirstOrDefault(c => c.Name == healerName);
            Character receiver = charaters.FirstOrDefault(c => c.Name == receiverName);

            Validator.EnsureCharacterIsNotNull(healer, healerName);
            Validator.EnsureCharacterIsNotNull(receiver, receiverName);

            if (healer is IHealable == false)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            Cleric cleric = (Cleric)healer;
            cleric.Heal(receiver);

            return $"{healerName} heals {receiverName} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            string output = "";

            List<Character> survivorCharacters = charaters.Where(c => c.IsAlive).ToList();
            if (survivorCharacters.Count == 0 || survivorCharacters.Count == 1)
            {
                lastSurvivorRounds++;
            }
            else
            {
                lastSurvivorRounds = 0;
            }

            foreach (Character character in survivorCharacters)
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                output += $"{character.Name} rests ({healthBeforeRest} => {character.Health})" + Environment.NewLine;
            }

            output = output.TrimEnd(Environment.NewLine.ToCharArray());

            return output;
        }

        public bool IsGameOver()
        {
            bool oneOrZeroSurvivorsLeft = charaters.Count(c => c.IsAlive) <= 1;
            return lastSurvivorRounds > 1 && oneOrZeroSurvivorsLeft;
        }
    }
}
