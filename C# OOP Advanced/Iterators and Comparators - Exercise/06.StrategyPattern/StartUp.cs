using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        SortedSet<Person> sortedByName = new SortedSet<Person>(new PersonNameComparer());
        SortedSet<Person> sortedByAge = new SortedSet<Person>(new PersonAgeComparer());

        int n = int.Parse(Console.ReadLine());

        for (int a = 0; a < n; a++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person(name, age);

            sortedByName.Add(person);
            sortedByAge.Add(person);
        }

        Print(sortedByName);
        Print(sortedByAge);
    }

    private static void Print(SortedSet<Person> persons)
    {
        foreach (Person person in persons)
        {
            Console.WriteLine(person.Name + " " + person.Age);
        }
    }
}
