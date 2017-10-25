using System;

class Program
{
    static void Main()
    {
        string word = Console.ReadLine();
        string sentence = Console.ReadLine();
        string censoredSentence = sentence.Replace(word, new string('*', word.Length));
        Console.WriteLine(censoredSentence);
    }
}