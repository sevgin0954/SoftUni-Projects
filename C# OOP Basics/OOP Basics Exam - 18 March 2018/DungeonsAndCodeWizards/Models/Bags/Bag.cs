using System.Collections.Generic;
using System.Linq;
using System;

using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards.Bags
{
    public abstract class Bag
    {
        int capacity = 100;
        readonly List<Item> items = new List<Item>();

        protected Bag(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity
        {
            get => capacity;
            private set { capacity = value; }
        }

        public IReadOnlyCollection<Item> Items
        {
            get => items;
        }

        public int Load => items.Sum(i => i.Weight);

        public void AddItem(Item item)
        {
            if (item.Weight + Load > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            items.Remove(item);

            return item;
        }
    }
}
