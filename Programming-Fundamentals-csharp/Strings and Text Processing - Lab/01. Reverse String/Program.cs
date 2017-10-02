using System;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        string reversed = "";
        for (int a = text.Length - 1; a >= 0; a--)
        {
            reversed += text[a];
        }
        Console.Write(reversed);
    }
}