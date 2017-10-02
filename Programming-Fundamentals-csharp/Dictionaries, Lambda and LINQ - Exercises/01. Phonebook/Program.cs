using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] command = Console.ReadLine().Split();
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        while (command[0] != "END")
        {
            string name = command[1];
            if (command[0] == "A")
            {
                string number = command[2];
                phoneBook[name] = number;
            }
            else if (command[0] == "S")
            {
                if (phoneBook.ContainsKey(name))
                {
                    Console.WriteLine($"{name} -> {phoneBook[name]}");
                }
                else
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }
            }
            command = Console.ReadLine().Split();
        }
    }
}