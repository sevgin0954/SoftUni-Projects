using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Regex regx = new Regex(@"\b(?:0x)?(\d|[A-F])+\b");
        MatchCollection matches = regx.Matches(input);
        foreach (Match match in matches)
        {
            Console.Write(match + " ");
        }
    }
}