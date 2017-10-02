using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] tickets = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        for (int a = 0; a < tickets.Length; a++)
        {
            if (tickets[a].Length != 20)
            {
                Console.WriteLine("invalid ticket");
                continue;
            }
            CheckTicket(tickets[a]);
        }
    }

    static void CheckTicket(string ticket)
    {
        Regex jackpot = new Regex(@"(@|#|\$|\^){6,9}(\1){10}");
        if (jackpot.IsMatch(ticket))
        {
            Console.WriteLine($"ticket \"{ticket}\" - 10{ticket[0]} Jackpot!");
            return;
        }
        Regex regx = new Regex(@"(@{6,9}|#{6,9}|\${6,9}|\^{6,9}).+?(\1)");
        if (regx.IsMatch(ticket))
        {
            Match match = regx.Match(ticket);
            Console.WriteLine($"ticket \"{ticket}\" - {match.Groups[1].Length}{match.Value[0]}");
        }
        else
        {
            Console.WriteLine($"ticket \"{ticket}\" - no match");
        }
    }
}