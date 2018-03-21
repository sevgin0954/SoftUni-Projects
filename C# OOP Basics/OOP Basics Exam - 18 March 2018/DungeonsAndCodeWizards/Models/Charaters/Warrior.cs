using System;

using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Contracts;

namespace DungeonsAndCodeWizards.Charaters
{
    public class Warrior : Character, IAttackable
    {
        const double BASE_HEALTH = 100;
        const double BASE_ARMOR = 50;
        const double ABILLITY_POINTS = 40;

        public Warrior(string name, Faction faction)
            : base(name, BASE_HEALTH, BASE_ARMOR, ABILLITY_POINTS, new Satchel(), faction) { }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
