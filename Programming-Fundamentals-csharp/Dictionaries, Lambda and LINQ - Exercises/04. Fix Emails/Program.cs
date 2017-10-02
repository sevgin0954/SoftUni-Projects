using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, string> usersEmail = new Dictionary<string, string>();
        while (true)
        {
            string user = Console.ReadLine();
            if (user == "stop")
            {
                break;
            }
            string email = Console.ReadLine();
            usersEmail[user] = email;
        }
        usersEmail = usersEmail.Where(p => !(p.Key.EndsWith("us") || p.Key.EndsWith("uk"))).ToDictionary(p => p.Key, p => p.Value);
        foreach (KeyValuePair<string, string> q in usersEmail)
        {
            Console.WriteLine($"{q.Key} -> {q.Value}");
        }
    }
}