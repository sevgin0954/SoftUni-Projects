using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(input, @"(?<day>\d{2})(?<separator>.|-|/)(?<month>[A-Z][a-z]{2})\k<separator>(?<year>\d{4})");
        foreach (Match match in matches)
        {
            Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
        }
    }
}