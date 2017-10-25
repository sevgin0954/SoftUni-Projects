using System;

class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split();
        Random random = new Random();
        for (int a = 0; a < words.Length; a++)
        {
            int randomIndex = random.Next(0, words.Length);
            string temp = words[a];
            words[a] = words[randomIndex];
            words[randomIndex] = temp;
        }
        Console.Write(String.Join("\r\n", words));
    }
}