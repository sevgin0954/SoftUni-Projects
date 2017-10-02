using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> domainsUsernames = new Dictionary<string, List<string>>();
        int n = int.Parse(Console.ReadLine());
        Regex regx = new Regex(@"(\b[a-zA-Z]{5,})@([a-z]{3,}(\.com|\.bg|\.org)\b)");
        for (int a = 0; a < n; a++)
        {
            string input = Console.ReadLine();
            if (regx.IsMatch(input) == false)
            {
                continue;
            }
            Match email = regx.Match(input);
            string username = email.Groups[1].Value;
            string domainName = email.Groups[2].Value;
            if (domainsUsernames.ContainsKey(domainName) == false)
            {
                domainsUsernames[domainName] = new List<string>();
            }
            if (domainsUsernames[domainName].Contains(username) == false)
            {
                domainsUsernames[domainName].Add(username);
            }
        }
        domainsUsernames = domainsUsernames.OrderBy(kvp => -kvp.Value.Count).ToDictionary(k => k.Key, v => v.Value);
        foreach (KeyValuePair<string, List<string>> domainUsername in domainsUsernames)
        {
            Console.WriteLine($"{domainUsername.Key}:");
            foreach (string username in domainUsername.Value)
            {
                Console.WriteLine($"### {username}");
            }
        }
    }
}