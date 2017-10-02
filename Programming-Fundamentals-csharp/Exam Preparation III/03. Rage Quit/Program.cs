using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(input, @"(?<text>[^\d]+)(?<num>\d+)");
        StringBuilder output = new StringBuilder();
        foreach (Match match in matches)
        {
            string text = match.Groups["text"].Value.ToUpper();
            int count = int.Parse(match.Groups["num"].Value);
            for (int a = 0; a < count; a++)
            {
                output.Append(text);
            }
        }
        int uniqueSymbolsCount = output.ToString().Distinct().Count();
        Console.WriteLine($"Unique symbols used: {uniqueSymbolsCount}");
        Console.Write(output);
    }
}