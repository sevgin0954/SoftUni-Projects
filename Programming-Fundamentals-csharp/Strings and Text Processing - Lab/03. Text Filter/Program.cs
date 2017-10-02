using System;

class Program
{
    static void Main()
    {
        string[] banWords = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string text = Console.ReadLine();
        for (int a = 0; a < banWords.Length; a++)
        {
            text = text.Replace(banWords[a], new string('*', banWords[a].Length));
        }
        Console.Write(text);
    }
}