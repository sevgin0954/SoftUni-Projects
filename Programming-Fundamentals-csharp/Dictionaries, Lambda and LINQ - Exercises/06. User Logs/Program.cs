using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, long>> citysCountrysPopulationCount = new Dictionary<string, Dictionary<string, long>>();
        while (true)
        {
            string[] input = Console.ReadLine().Split('|');
            if (input[0] == "report")
            {
                break;
            }
            string city = input[0];
            string country = input[1];
            int populationCount = int.Parse(input[2]);
            if (!citysCountrysPopulationCount.ContainsKey(country))
            {
                citysCountrysPopulationCount[country] = new Dictionary<string, long>();
            }
            if (citysCountrysPopulationCount[country].ContainsKey(city))
            {
                citysCountrysPopulationCount[country][city] += populationCount;
            }
            else
            {
                citysCountrysPopulationCount[country][city] = populationCount;
            }
        }
        Dictionary<string, Dictionary<string, long>> sortedDictionary = citysCountrysPopulationCount
            .OrderBy(kvp => -kvp.Value.Values.Sum())
            .ToDictionary(a => a.Key, b => b.Value);
        foreach (KeyValuePair<string, Dictionary<string, long>> a in sortedDictionary)
        {
            Console.WriteLine($"{a.Key} (total population: {a.Value.Values.Sum()})");
            foreach (KeyValuePair<string, long> c in a.Value.OrderBy(aa => -aa.Value))
            {
                Console.WriteLine($"=>{c.Key}: {c.Value}");
            }
        }
    }
}