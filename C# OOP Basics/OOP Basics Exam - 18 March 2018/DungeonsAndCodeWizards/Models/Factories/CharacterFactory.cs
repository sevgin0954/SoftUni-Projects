using System;

using DungeonsAndCodeWizards.Charaters;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string factionName, string type, string name)
        {
            Faction faction = 0;

            if (Enum.TryParse<Faction>(factionName, out faction) == false)
            {
                throw new ArgumentException($"Invalid faction \"{factionName}\"!");
            }

            switch (type)
            {
                case "Warrior":
                    return new Warrior(name, faction);
                case "Cleric":
                    return new Cleric(name, faction);
                default:
                    throw new ArgumentException($"Invalid character type \"{type}\"!");
            }
        }
    }
}
