using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, List<Pokemon>> namesTypesIndexes = new Dictionary<string, List<Pokemon>>();
        while (true)
        {
            string[] input = Console.ReadLine().Split("-, >".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (input[0] == "wubbalubbadubdub")
            {
                break;
            }
            string name = input[0];
            if (input.Length == 1)
            {
                if (namesTypesIndexes.ContainsKey(name))
                {
                    foreach (KeyValuePair<string, List<Pokemon>> nameTypeIndex in namesTypesIndexes)
                    {
                        if (nameTypeIndex.Key == name)
                        {
                            Console.WriteLine($"# {nameTypeIndex.Key}");
                            foreach (Pokemon pok in nameTypeIndex.Value)
                            {
                                Console.WriteLine($"{pok.Type} <-> {pok.Index}");
                            }
                        }
                    }
                }
                continue;
            }
            string type = input[1];
            int index = int.Parse(input[2]);
            Pokemon pokemon = new Pokemon
            {
                Type = type,
                Index = index
            };
            if (namesTypesIndexes.ContainsKey(name) == false)
            {
                namesTypesIndexes[name] = new List<Pokemon>();
            }
            namesTypesIndexes[name].Add(pokemon);
        }
        foreach (KeyValuePair<string, List<Pokemon>> namesPokemons in namesTypesIndexes)
        {
            Console.WriteLine($"# {namesPokemons.Key}");
            foreach (Pokemon pok in namesPokemons.Value.OrderBy(p => -p.Index))
            {
                Console.WriteLine($"{pok.Type} <-> {pok.Index}");
            }
        }
    }
}

class Pokemon
{
    public string Type { get; set; }
    public int Index { get; set; }
}