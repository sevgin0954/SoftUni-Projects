using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string key = Console.ReadLine();
        string text = Console.ReadLine();
        Match match = Regex.Match(key, @"(?<startKey>[a-zA-Z]+)(\||<|\\).*(\||<|\\)(?<endKey>[a-zA-Z]+)");
        string startKey = match.Groups["startKey"].Value;
        string endKey = match.Groups["endKey"].Value;
        string pattern = $"(?<={startKey}).*?(?={endKey})";
        MatchCollection matches = Regex.Matches(text, pattern);
        bool isEmpty = true;
        foreach (Match m in matches)
        {
            if (m.Value != "")
            {
                isEmpty = false;
            }
            Console.Write(m.Value);
        }
        if (isEmpty)
        {
            Console.WriteLine("Empty result");
        }
    }
}