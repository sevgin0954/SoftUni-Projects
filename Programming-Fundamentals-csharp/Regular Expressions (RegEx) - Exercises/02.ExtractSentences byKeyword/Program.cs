using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string keyword = Console.ReadLine();
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(input, @"[^.!?;]*([^.!?;]|\s|^)" + keyword + @"([.!?;]|\s)[^.!?;]*");
        foreach (Match match in matches)
        {
            Console.WriteLine(match);
        }
    }
}