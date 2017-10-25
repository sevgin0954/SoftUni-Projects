using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var dict = new Dictionary<string, SortedDictionary<string, Dictionary<string, int>>>();
        int n = int.Parse(Console.ReadLine());
        for (int a = 0; a < n; a++)
        {
            string[] input = Console.ReadLine().Split();
            while (input.Contains("null"))
            {
                int index = Array.IndexOf(input, "null");
                switch (index)
                {
                    case 2:
                        input[index] = "45";
                        break;
                    case 3:
                        input[index] = "250";
                        break;
                    case 4  :
                        input[index] = "10";
                        break;
                }
            }
            string type = input[0];
            string name = input[1];
            int damage = int.Parse(input[2]);
            int health = int.Parse(input[3]);
            int armor = int.Parse(input[4]);
            if (!dict.ContainsKey(type))
            {
                dict[type] = new SortedDictionary<string, Dictionary<string, int>>();
            }
            if (!dict[type].ContainsKey(name))
            {
                dict[type][name] = new Dictionary<string, int>();
            }
            dict[type][name]["damage"] = damage;
            dict[type][name]["health"] = health;
            dict[type][name]["armor"] = armor;
        }
        foreach (KeyValuePair<string, SortedDictionary<string, Dictionary<string, int>>> a in dict)
        {
            double averageDamage = 0;
            double averageHealth = 0;
            double averageArmor = 0;
            int avgDmgCount = 0;
            int avgHlCount = 0;
            int avgArmCount = 0;
            foreach (KeyValuePair<string, Dictionary<string, int>> sum in a.Value)
            {
                foreach (KeyValuePair<string, int> u in sum.Value)
                {
                    if (u.Key == "damage")
                    {
                        averageDamage += u.Value;
                        avgDmgCount++;
                    }
                    else if (u.Key == "health")
                    {
                        averageHealth += u.Value;
                        avgHlCount++;
                    }
                    else
                    {
                        averageArmor += u.Value;
                        avgArmCount++;
                    }
                }
            }
            Console.WriteLine($"{a.Key}::({averageDamage / avgDmgCount:f2}/{averageHealth / avgHlCount:f2}/{averageArmor / avgArmCount:f2})");
            foreach (KeyValuePair<string, Dictionary<string, int>> b in a.Value)
            {
                Console.Write($"-{b.Key} -> ");
                bool isFirst = true;
                foreach (KeyValuePair<string, int> c in b.Value)
                {
                    if (isFirst == false)
                    {
                        Console.Write(", ");
                    }
                    isFirst = false;
                    Console.Write($"{c.Key}: {c.Value}");
                }
                Console.WriteLine();
            }
        }
    }
}