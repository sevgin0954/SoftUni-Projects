using DungeonsAndCodeWizards.Charaters;
using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards.Items
{
    public class HealthPotion : Item
    {
        const int WEIGHT = 5;
        const double HEALTH_RESTORE = 20;

        public HealthPotion()
            : base(WEIGHT) { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += HEALTH_RESTORE;
        }
    }
}
