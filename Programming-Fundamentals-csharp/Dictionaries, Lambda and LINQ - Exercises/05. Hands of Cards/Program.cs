using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "JOKER")
            {
                break;
            }
            string name = command.Substring(0, command.IndexOf(':'));
            string[] cards = command.Remove(0, command.IndexOf(':') + 2).Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
            int[] nums = GetNumsFromCards(cards);
            string[] powers = GetPowersFromCards(cards);
            for (int a = 0; a < powers.Length; a++)
            {
                int multiplier = 1;
                switch (powers[a])
                {
                    case "S":
                        multiplier = 4;
                        break;
                    case "H":
                        multiplier = 3;
                        break;
                    case "D":
                        multiplier = 2;
                        break;
                }
                if (dict.ContainsKey(name))
                {
                    dict[name] += nums[a] * multiplier;
                }
                else
                {
                    dict[name] = nums[a] * multiplier;
                }
            }
        }
        foreach (KeyValuePair<string, int> player in dict)
        {
            Console.WriteLine($"{player.Key}: {player.Value}");
        }
    }

    static int[] GetNumsFromCards(string[] cards)
    {
        int[] nums = new int[cards.Length];
        for (int a = 0; a < cards.Length; a++)
        {
            string temp = cards[a].Substring(0, cards[a].Length - 1);
            switch (temp)
            {
                case "J":
                    nums[a] = 11;
                    break;
                case "Q":
                    nums[a] = 12;
                    break;
                case "K":
                    nums[a] = 13;
                    break;
                case "A":
                    nums[a] = 14;
                    break;
                default:
                    nums[a] = int.Parse(temp);
                    break;
            }
        }
        return nums;
    }

    static string[] GetPowersFromCards(string[] cards)
    {
        string[] powers = new string[cards.Length];
        powers = cards.Select(a => a.Substring(a.Length - 1).ToString()).ToArray();
        return powers;
    }
}