using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        string[] itemsQuantitys = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        var ItemsTypeItemsAmounts = new Dictionary<string, Dictionary<string, long>>();

        long goldAmount = 0;
        long gemAmount = 0;
        long cashAmount = 0;
        long currentIndex = 0;

        while (currentIndex < itemsQuantitys.Length - 1)
        {
            string itemType = "";
            string itemName = itemsQuantitys[currentIndex++];
            long amount = long.Parse(itemsQuantitys[currentIndex++]);

            if (itemName.Length == 3)
            {
                itemType = "Cash";

                if (cashAmount + amount <= gemAmount && bagCapacity - amount >= 0)
                {
                    bagCapacity -= amount;
                    cashAmount += amount;

                    if (ItemsTypeItemsAmounts.ContainsKey(itemType) == false)
                    {
                        ItemsTypeItemsAmounts[itemType] = new Dictionary<string, long>();
                    }

                    if (ItemsTypeItemsAmounts[itemType].ContainsKey(itemName) == false)
                    {
                        ItemsTypeItemsAmounts[itemType][itemName] = amount;
                    }
                    else
                    {
                        ItemsTypeItemsAmounts[itemType][itemName] += amount;
                    }
                }
            }
            else if (itemName.ToLower().EndsWith("gem"))
            {
                itemType = "Gem";

                if (gemAmount + amount <= goldAmount && bagCapacity - amount >= 0)
                {
                    bagCapacity -= amount;
                    gemAmount += amount;

                    if (ItemsTypeItemsAmounts.ContainsKey(itemType) == false)
                    {
                        ItemsTypeItemsAmounts[itemType] = new Dictionary<string, long>();
                    }

                    if (ItemsTypeItemsAmounts[itemType].ContainsKey(itemName) == false)
                    {
                        ItemsTypeItemsAmounts[itemType][itemName] = amount;
                    }
                    else
                    {
                        ItemsTypeItemsAmounts[itemType][itemName] += amount;
                    }
                }
            }
            else if (itemName.ToLower() == "gold")
            {
                itemType = "Gold";

                if (bagCapacity - amount >= 0)
                {
                    bagCapacity -= amount;
                    goldAmount += amount;

                    if (ItemsTypeItemsAmounts.ContainsKey(itemType) == false)
                    {
                        ItemsTypeItemsAmounts[itemType] = new Dictionary<string, long>();
                    }

                    if (ItemsTypeItemsAmounts[itemType].ContainsKey(itemName) == false)
                    {
                        ItemsTypeItemsAmounts[itemType][itemName] = amount;
                    }
                    else
                    {
                        ItemsTypeItemsAmounts[itemType][itemName] += amount;
                    }
                }
            }
        }

        foreach (var itemType in ItemsTypeItemsAmounts.OrderByDescending(itia => itia.Value.Sum(ia => ia.Value)))
        {
            long totalAmount = 0;

            switch (itemType.Key)
            {
                case "Gold":
                    totalAmount = goldAmount;
                    break;
                case "Gem":
                    totalAmount = gemAmount;
                    break;
                case "Cash":
                    totalAmount = cashAmount;
                    break;
            }

            Console.WriteLine($"<{itemType.Key}> ${totalAmount}");

            foreach (var itemAmount in itemType.Value.OrderByDescending(ia => ia.Key).ThenBy(ia => ia.Value))
            {
                Console.WriteLine($"##{itemAmount.Key} - {itemAmount.Value}");
            }
        }
    }
}