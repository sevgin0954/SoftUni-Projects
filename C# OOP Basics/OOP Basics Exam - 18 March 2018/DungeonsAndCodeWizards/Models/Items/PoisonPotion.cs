using DungeonsAndCodeWizards.Charaters;
using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards.Items
{
    public class PoisonPotion : Item
    {
        const int WEIGHT = 5;

        public PoisonPotion()
            : base(WEIGHT) { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;
        }
    }
}
