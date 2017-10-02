using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        MatchCollection emails = Regex.Matches(input, @"(?<=\s)[a-zA-Z0-9]+(\w*[.-]?)*@([a-z]+[.-])+[a-z]+");
        foreach (Match match in emails)
        {
            Console.WriteLine(match);
        }
    }
}