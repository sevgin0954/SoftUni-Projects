using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        List<IIdentity> persons = new List<IIdentity>();

        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "End")
            {
                break;
            }
            if (input.Length == 2)
            {
                Robot personToAdd = new Robot(input[0], input[1]);
                persons.Add(personToAdd);
            }
            else if (input.Length == 3)
            {
                Citizen personToAdd = new Citizen(input[0], int.Parse(input[1]), input[2]);
                persons.Add(personToAdd);
            }
        }

        string detaintId = Console.ReadLine();
        persons = persons.Where(p => p.Id.EndsWith(detaintId)).ToList();

        PrintIds(persons);
    }

    static void PrintIds(List<IIdentity> persons)
    {
        foreach (IIdentity person in persons)
        {
            Console.WriteLine(person.Id);
        }
    }
}
