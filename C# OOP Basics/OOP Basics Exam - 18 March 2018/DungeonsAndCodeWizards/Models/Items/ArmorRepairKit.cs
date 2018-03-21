using DungeonsAndCodeWizards.Charaters;
using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards.Items
{
    public class ArmorRepairKit : Item
    {
        const int WEIGHT = 10;

        public ArmorRepairKit()
            : base(WEIGHT) { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Armor = character.BaseArmor;
        }
    }
}
