using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var usersIpsDurations = new SortedDictionary<string, SortedDictionary<string, int>>();
        int n = int.Parse(Console.ReadLine());
        for (int a = 0; a < n; a++)
        {
            string[] input = Console.ReadLine().Split();
            string userName = input[1];
            string ip = input[0];
            int duration = int.Parse(input[2]);
            if (!usersIpsDurations.ContainsKey(userName))
            {
                usersIpsDurations[userName] = new SortedDictionary<string, int>();
            }
            if (usersIpsDurations[userName].ContainsKey(ip))
            {
                usersIpsDurations[userName][ip] += duration;
            }
            else
            {
                usersIpsDurations[userName][ip] = duration;
            }
        }
        foreach (KeyValuePair<string, SortedDictionary<string, int>> userIpDuration in usersIpsDurations)
        {
            Console.Write($"{userIpDuration.Key}: ");
            bool isFirst = true;
            foreach (KeyValuePair<string, int> IpDuration in userIpDuration.Value)
            {
                if (isFirst)
                {
                    Console.Write($"{userIpDuration.Value.Values.Sum()} [{IpDuration.Key}");
                    isFirst = false;
                }
                else
                {
                    Console.Write($", {IpDuration.Key}");
                }
            }
            Console.WriteLine("]");
        }
    }
}