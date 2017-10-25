using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        Regex regx = new Regex(@"\b[A-Z][a-z]+\b \b[A-Z][a-z]+\b");
        MatchCollection matches = regx.Matches(text);
        if (regx.IsMatch(text))
        {
            foreach (Match match in matches)
            {
                Console.Write(match + " ");
            }
        }
    }
}