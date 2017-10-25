using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine().ToLower().Split();
        Dictionary<string, int> dict = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (dict.ContainsKey(word))
            {
                dict[word]++;
            }
            else
            {
                dict[word] = 1;
            }
        }
        bool isFirst = true;
        foreach (KeyValuePair<string, int> d in dict)
        {
            if (d.Value % 2 == 1)
            {
                if (!isFirst)
                {
                    Console.Write(", ");
                }
                isFirst = false;
                Console.Write(d.Key);
            }
        }
    }
}