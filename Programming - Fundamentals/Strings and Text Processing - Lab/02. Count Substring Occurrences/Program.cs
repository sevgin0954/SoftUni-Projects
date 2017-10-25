using System;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine().ToLower();
        string substring = Console.ReadLine().ToLower();
        int count = 0;
        int index = -1;
        while (true)
        {
            index = text.IndexOf(substring, index + 1);
            if (index == -1)
            {
                break;
            }
            count++;
        }
        Console.Write(count);
    }
}