using DungeonsAndCodeWizards.Charaters;

namespace DungeonsAndCodeWizards.Models
{
    public abstract class Item
    {
        int weight;

        protected Item(int weight)
        {
            Weight = weight;
        }

        public int Weight
        {
            get => weight;
            private set { weight = value; }
        }

        public virtual void AffectCharacter(Character character)
        {
            character.EnsureAlive();
        }
    }
}
