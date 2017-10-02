using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] participants = Regex.Split(Console.ReadLine(), @"\s*,\s+");
        string[] songs = Regex.Split(Console.ReadLine(), @"\s*,\s+");
        Dictionary<string, List<string>> namesAwards = new Dictionary<string, List<string>>();
        while (true)
        {
            string[] input = Regex.Split(Console.ReadLine(), @"\s*,\s+");
            if (input[0] == "dawn")
            {
                break;
            }
            string name = input[0];
            string song = input[1];
            string award = input[2];
            if (participants.Contains(name) == false || songs.Contains(song) == false)
            {
                continue;
            }
            if (namesAwards.ContainsKey(name) == false)
            {
                namesAwards[name] = new List<string>();
            }
            if (namesAwards[name].Contains(award) == false)
            {
                namesAwards[name].Add(award);
            }
        }
        namesAwards = namesAwards.
            OrderByDescending(kvp => kvp.Value.Count).
            ThenBy(kvp => kvp.Key).
            ToDictionary(k => k.Key, v => v.Value);
        if (namesAwards.Count == 0)
        {
            Console.Write("No awards");
        }
        else
        {
            foreach (KeyValuePair<string, List<string>> nameAward in namesAwards)
            {
                Console.WriteLine($"{nameAward.Key}: {nameAward.Value.Count} awards");
                foreach (string award in nameAward.Value.OrderBy(a => a))
                {
                    Console.WriteLine($"--{award}");
                }
            }
        }
    }
}