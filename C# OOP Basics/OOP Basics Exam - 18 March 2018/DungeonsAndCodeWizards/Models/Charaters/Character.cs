using System;

using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards.Charaters
{
    public abstract class Character
    {
        string name;
        double baseHealth;
        double health;
        double baseArmor;
        double armor;
        double abilityPoints;
        Bag bag = null;
        Faction faction;
        bool isAlive = true;
        double restHealMultiplier = 0.2;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            BaseArmor = armor;
            BaseHealth = health;
            Name = name;
            Health = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            Faction = faction;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        public double BaseHealth
        {
            get => baseHealth;
            private set { baseHealth = value; }
        }

        public double Health
        {
            get => health;
            set
            {
                health = value;

                if (health > BaseHealth)
                {
                    health = BaseHealth;
                }
                if (health <= 0)
                {
                    IsAlive = false;
                    health = 0;
                }
            }
        }

        public double BaseArmor
        {
            get => baseArmor;
            private set { baseArmor = value; }
        }

        public double Armor
        {
            get => armor;
            set
            {
                armor = value;
                if (armor > BaseArmor)
                {
                    armor = BaseArmor;
                }
            }
        }

        public double AbilityPoints
        {
            get => abilityPoints;
            private set { abilityPoints = value; }
        }

        public Bag Bag
        {
            get => bag;
            private set { bag = value; }
        }

        public Faction Faction
        {
            get => faction;
            private set { faction = value; }
        }

        public bool IsAlive
        {
            get => isAlive;
            private set { isAlive = value; }
        }

        public virtual double RestHealMultiplier
        {
            get => restHealMultiplier;
            private set { restHealMultiplier = value; }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (hitPoints > Armor)
            {
                hitPoints -= Armor;
                Armor = 0;
                Health -= hitPoints;
            }
            else
            {
                Armor -= hitPoints;
            }
        }

        public void Rest()
        {
            EnsureAlive();

            Health += BaseHealth * RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            EnsureAlive();
            character.EnsureAlive();

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            EnsureAlive();
            character.EnsureAlive();

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            EnsureAlive();
            Bag.AddItem(item);
        }

        public void EnsureAlive()
        {
            if (IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public override string ToString()
        {
            string liveStatus = IsAlive ? "Alive" : "Dead";
            return $"{Name} - HP: {Health}/{BaseHealth}, AP: {Armor}/{BaseArmor}, Status: {liveStatus}";
        }
    }
}
