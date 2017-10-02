using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            Dictionary<string, List<string>> keysValues = new Dictionary<string, List<string>>();
            MatchCollection matches = Regex.Matches(input, @"(?<key>[^&?]*)=(?<value>[^&?]*)");
            foreach (Match match in matches)
            {
                string key = match.Groups["key"].Value;
                string value = match.Groups["value"].Value;
                key = Regex.Replace(key, @"(\+|%20)+", " ").Trim();
                value = Regex.Replace(value, @"(\+|%20)+", " ").Trim();
                if (keysValues.ContainsKey(key))
                {
                    keysValues[key].Add(value);
                }
                else
                {
                    keysValues[key] = new List<string>();
                    keysValues[key].Add(value);
                }
            }
            PrintDict(keysValues);
        }
    }

    static void PrintDict(Dictionary<string, List<string>> dict)
    {
        foreach (KeyValuePair<string, List<string>> d in dict)
        {
            Console.Write(d.Key + "=");
            bool isFirst = true;
            Console.Write("[");
            foreach (string value in d.Value)
            {
                if (isFirst == false)
                {
                    Console.Write(", ");
                }
                isFirst = false;
                Console.Write(value);
            }
            Console.Write("]");
        }
        Console.WriteLine();
    }

    static string Trim(string str)
    {
        while (str.EndsWith("%20") || str.StartsWith("%20") || str.EndsWith("+") || str.StartsWith("+"))
        {
            while (str.EndsWith("%20"))
            {
                str = new string(str.Take(str.Length - 3).ToArray());
            }
            while (str.StartsWith("%20"))
            {
                str = new string(str.Skip(3).ToArray());
            }
            str = str.Trim('+');
        }
        return str;
    }
}