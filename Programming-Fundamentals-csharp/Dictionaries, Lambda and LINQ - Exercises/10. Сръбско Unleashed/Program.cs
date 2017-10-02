﻿using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> venuesSingersEarnings = new Dictionary<string, Dictionary<string, int>>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }
            if (input.Contains(" @") == false)
            {
                continue;
            }
            string singerName = input.Substring(0, input.IndexOf(" @"));
            if (singerName.Split().Length > 3)
            {
                continue;
            }
            string[] splitInput = input.Substring(input.IndexOf("@") + 1).Split();
            if (splitInput.Length < 3)
            {
                continue;
            }
            string[] placeInParts = splitInput.Take(splitInput.Length - 2).ToArray();
            if (placeInParts.Length > 3)
            {
                continue;
            }
            string place = String.Join(" ", placeInParts);
            int ticketPrice = 0;
            int ticketCount = 0;
            if (!int.TryParse(splitInput[splitInput.Length - 2], out ticketPrice))
            {
                continue;
            }
            if (!int.TryParse(splitInput[splitInput.Length - 1], out ticketCount))
            {
                continue;
            }
            int totalEarning = ticketCount * ticketPrice;
            if (!venuesSingersEarnings.ContainsKey(place))
            {
                venuesSingersEarnings[place] = new Dictionary<string, int>();
            }
            if (venuesSingersEarnings[place].ContainsKey(singerName))
            {
                venuesSingersEarnings[place][singerName] += totalEarning;
            }
            else
            {
                venuesSingersEarnings[place][singerName] = totalEarning;
            }
        }
        foreach (KeyValuePair<string, Dictionary<string, int>> venueSingerEarning in venuesSingersEarnings)
        {
            Console.WriteLine($"{venueSingerEarning.Key}");
            foreach (KeyValuePair<string, int> singerEarning in venueSingerEarning.Value.OrderBy(kvp => -kvp.Value))
            {
                Console.WriteLine($"#  {singerEarning.Key} -> {singerEarning.Value}");
            }
        }
    }
}