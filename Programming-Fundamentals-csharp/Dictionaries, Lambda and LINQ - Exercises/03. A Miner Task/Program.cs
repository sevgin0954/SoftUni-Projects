using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> resources = new Dictionary<string, int>();
        string resource = Console.ReadLine();
        while (resource != "stop")
        {
            int quantity = int.Parse(Console.ReadLine());
            if (resources.ContainsKey(resource))
            {
                resources[resource] += quantity;
            }
            else
            {
                resources[resource] = quantity;
            }
            resource = Console.ReadLine();
        }
        foreach (KeyValuePair<string, int> q in resources)
        {
            Console.WriteLine($"{q.Key} -> {q.Value}");
        }
    }
}