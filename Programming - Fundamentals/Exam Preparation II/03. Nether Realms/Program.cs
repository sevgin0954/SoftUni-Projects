using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] names = Regex.Split(Console.ReadLine(), @"\s*,\s*");
        SortedDictionary<string, double[]> namesHealthsDmgs = new SortedDictionary<string, double[]>();
        for (int a = 0; a < names.Length; a++)
        {
            string name = names[a];
            long health = CalculteHealth(name);
            double dmg = CalculateDmg(name);
            namesHealthsDmgs[name] = new double[]
            {
                health,
                dmg
            };
        }
        foreach (KeyValuePair<string, double[]> nameHealthDmg in namesHealthsDmgs)
        {
            Console.WriteLine($"{nameHealthDmg.Key} - {nameHealthDmg.Value[0]} health, {nameHealthDmg.Value[1]:f2} damage");
        }
    }

    static long CalculteHealth(string input)
    {
        long sum = 0;
        MatchCollection chars = Regex.Matches(input, @"[^+\-*\/\.\d]");
        foreach (Match ch in chars)
        {
            sum += ch.Value[0];
        }
        return sum;
    }

    static double CalculateDmg(string input)
    {
        double dmg = 0;
        MatchCollection nums = Regex.Matches(input, @"[+-]*\d+\.*\d*");
        foreach (Match num in nums)
        {
            dmg += double.Parse(num.Value);
        }
        MatchCollection matches = Regex.Matches(input, @"[\/*]");
        foreach (Match match in matches)
        {
            if (match.Value == "/")
            {
                dmg /= 2;
            }
            else
            {
                dmg *= 2;
            }
        }
        return dmg;
    }
}