using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedDictionary<string, string> phoneBook = new SortedDictionary<string, string>();
        string[] command = Console.ReadLine().Split();
        while (command[0] != "END")
        {
            if (command[0] == "A")
            {

                string name = command[1];
                phoneBook[name] = command[2];
            }
            else if (command[0] == "S")
            {

                string name = command[1];
                if (phoneBook.ContainsKey(name))
                {
                    Console.WriteLine($"{name} -> {phoneBook[name]}");
                }
                else
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }
            }
            else if (command[0] == "ListAll")
            {
                foreach (KeyValuePair<string ,string> a in phoneBook)
                {
                    Console.WriteLine($"{a.Key} -> {a.Value}");
                }
            }
            command = Console.ReadLine().Split();
        }
    }
}