using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split(" .,?!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
        string polidromWords = "";
        for (int a = 0; a < words.Length; a++)
        {
            string reversed = new string(words[a].Reverse().ToArray());
            if (reversed == words[a])
            {
                polidromWords += words[a] + ", ";
            }
        }
        string[] arr = polidromWords.Split(", ".ToArray(), StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(arr);
        Console.WriteLine(string.Join(", ", arr));
    }
}