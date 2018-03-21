using System;

using DungeonsAndCodeWizards.Items;
using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string type)
        {
            switch (type)
            {
                case "ArmorRepairKit":
                    return new ArmorRepairKit();
                case "HealthPotion":
                    return new HealthPotion();
                case "PoisonPotion":
                    return new PoisonPotion();
                default:
                    throw new ArgumentException($"Invalid item \"{type}\"!");

            }
        }
    }
}
