using System;

class Program
{
    static void Main()
    {
        string names = Console.ReadLine();
        Action<string> printNamesOnNewLine = (s) => Console.Write(string.Join(Environment.NewLine, s.Split(' ')));

        printNamesOnNewLine(names);
    }
}