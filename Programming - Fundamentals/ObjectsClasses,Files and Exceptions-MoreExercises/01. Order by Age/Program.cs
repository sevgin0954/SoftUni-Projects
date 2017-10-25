using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string Name { get; set; }
    public string Id { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        List<Person> persons = new List<Person>();
        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "End")
            {
                break;
            }
            string name = input[0];
            string id = input[1];
            int age = int.Parse(input[2]);
            Person person = new Person
            {
                Name = name,
                Id = id,
                Age = age
            };
            persons.Add(person);
        }
        persons = persons.OrderBy(p => p.Age).ToList();
        foreach (Person person in persons)
        {
            Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
        }
    }
}