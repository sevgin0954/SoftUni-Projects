using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string map = Console.ReadLine();
        while (true)
        {
            string[] hideCount = Console.ReadLine().Split();
            string hide = hideCount[0];
            int count = int.Parse(hideCount[1]);
            string pattern = $"\\{hide}{{{count},}}";
            Regex regx = new Regex(pattern);
            if (regx.IsMatch(map))
            {
                MatchCollection matches = regx.Matches(map);
                string hideout = "";
                int bestLen = 0;
                foreach (Match match in matches)
                {
                    if (match.Value.Length > bestLen)
                    {
                        hideout = match.Value;
                        bestLen = match.Value.Length;
                    }
                }
                int index = map.IndexOf(hideout);
                Console.Write($"Hideout found at index {index} and it is with size {bestLen}!");
                return;
            }
        }
    }
}