using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        char[] separators = { '.', ',', ':', '(', ')', '[', ']', '"', '\'', '\\', '!', '?', ' '};
        string[] words = Console.ReadLine().ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
        words = words.Where(a => a.Length < 5).ToArray();
        words = words.Distinct().ToArray();
        words = words.OrderBy(a => a).ToArray();
        Console.Write(String.Join(", ", words));
    }
}