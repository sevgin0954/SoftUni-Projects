using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Person[] persons = new Person[n];
        for (int a = 0; a < n; a++)
        {
            string[] nameAge = Console.ReadLine().Split(' ').ToArray();
            string name = nameAge[0];
            int age = int.Parse(nameAge[1]);
            persons[a] = new Person
            {
                Age = age,
                Name = name
            };
        }
        Console.WriteLine();
        persons = persons.Where(p => p.Age > 30).OrderBy(p => p.Name).ToArray();
        for (int a = 0; a < persons.Length; a++)
        {
            Console.WriteLine(persons[a].Name + " - " + persons[a].Age);
        }
    }
}