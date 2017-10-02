using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Regex didiRegex = new Regex(@"[^a-zA-Z-]+");
        Regex bojoRegx = new Regex(@"[a-zA-Z]+-[a-zA-Z]+");
        while (true)
        {
            if (didiRegex.IsMatch(input) == false)
            {
                break;
            }
            Match didiMatch = didiRegex.Match(input);
            Console.WriteLine(didiMatch.Value);
            input = input.Substring(input.IndexOf(didiMatch.Value));
            if (bojoRegx.IsMatch(input) == false)
            {
                break;
            }
            Match bojoMatch = bojoRegx.Match(input);
            Console.WriteLine(bojoMatch.Value);
            input = input.Substring(input.IndexOf(bojoMatch.Value));
        }
    }
}