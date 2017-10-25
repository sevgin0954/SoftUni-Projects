using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        SortedDictionary<string, int> keyMaterialsCount = new SortedDictionary<string, int>
        {
            { "shards", 0 },
            { "fragments", 0 },
            { "motes", 0 },
        };
        SortedDictionary<string, int> trashMaterialsCount = new SortedDictionary<string, int>();
        bool isLegendaryItemObtainded = false;
        while (isLegendaryItemObtainded == false)
        {
            string[] input = Console.ReadLine().ToLower().Split();
            while (input.Length > 0)
            {
                string material = input[1];
                int quantity = int.Parse(input[0]);
                input = input.Skip(2).ToArray();
                if (material == "shards" || material == "fragments" || material == "motes")
                {
                    keyMaterialsCount[material] += quantity;
                    if (keyMaterialsCount[material] >= 250)
                    {
                        keyMaterialsCount[material] -= 250;
                        if (material == "shards")
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            isLegendaryItemObtainded = true;
                            break;
                        }
                        else if (material == "fragments")
                        {
                            Console.WriteLine("Valanyr obtained!");
                            isLegendaryItemObtainded = true;
                            break;
                        }
                        else if (material == "motes")
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            isLegendaryItemObtainded = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (trashMaterialsCount.ContainsKey(material))
                    {
                        trashMaterialsCount[material] += quantity;
                    }
                    else
                    {
                        trashMaterialsCount[material] = quantity;
                    }
                }

            }
        }
        foreach (KeyValuePair<string, int> materialCount in keyMaterialsCount.OrderBy(kvp => -kvp.Value))
        {
            Console.WriteLine($"{materialCount.Key}: {materialCount.Value}");
        }
        foreach (KeyValuePair<string, int> materialCount in trashMaterialsCount)
        {
            Console.WriteLine($"{materialCount.Key}: {materialCount.Value}");
        }
    }
}