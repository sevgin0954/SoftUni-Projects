using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        List<Person> persons = new List<Person>();

        while (true)
        {
            string[] input = Console.ReadLine().Split();

            if (input[0] == "END")
            {
                break;
            }

            string name = input[0];
            int age = int.Parse(input[1]);
            string townName = input[2];
            Person personToAdd = new Person(name, age, townName);

            persons.Add(personToAdd);
        }

        int n = int.Parse(Console.ReadLine()) - 1;
        Person personToCompare = persons[n];

        int equalCount = 0;

        foreach (Person person in persons)
        {
            if (person.CompareTo(personToCompare) == 0)
            {
                equalCount++;
            }
        }

        if (equalCount == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            int personsCount = persons.Count;
            int notEqualCount = personsCount - equalCount;

            Console.WriteLine($"{equalCount} {notEqualCount} {personsCount}");
        }
    }
}
