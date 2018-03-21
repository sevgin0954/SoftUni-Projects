using System;

using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Contracts;

namespace DungeonsAndCodeWizards.Charaters
{
    public class Cleric : Character, IHealable
    {
        const double BASE_HEALTH = 50;
        const double BASE_ARMOR = 25;
        const double ABILLITY_POINTS = 40;

        public Cleric(string name, Faction faction)
            : base(name, BASE_HEALTH, BASE_ARMOR, ABILLITY_POINTS, new Backpack(), faction) { }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
