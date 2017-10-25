using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var idsEventsParticipants = new Dictionary<int, Dictionary<string, List<string>>>();
        List<string> events = new List<string>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Time for Code")
            {
                break;
            }
            Regex idEventMatch = new Regex(@"(?<id>\d+)\s+#(?<event>.+?)(?=$|\s+@)");
            Regex participantsMatch = new Regex(@"@\S+");
            if (idEventMatch.IsMatch(input) == false)
            {
                continue;
            }
            Match idEvent = idEventMatch.Match(input);
            MatchCollection particpants = participantsMatch.Matches(input);
            int id = int.Parse(idEvent.Groups["id"].Value);
            string eventName = idEvent.Groups["event"].Value;
            if (idsEventsParticipants.ContainsKey(id))
            {
                if (idsEventsParticipants[id].ContainsKey(eventName) == false)
                {
                    continue;
                }
            }
            else
            {
                idsEventsParticipants[id] = new Dictionary<string, List<string>>();
                idsEventsParticipants[id][eventName] = new List<string>();
            }
            foreach (Match participant in particpants)
            {
                if (idsEventsParticipants[id][eventName].Contains(participant.Value) == false)
                {
                    idsEventsParticipants[id][eventName].Add(participant.Value);
                }
            }
        }
        foreach (var idEventParticipant in idsEventsParticipants.OrderByDescending(kvp => kvp.Value.Values.First().Count).ThenBy(kvp => kvp.Value.Keys.First()))
        {
            Console.WriteLine($"{idEventParticipant.Value.Keys.First()} - {idEventParticipant.Value.Values.First().Count}");
            foreach (string participant in idEventParticipant.Value.Values.First().OrderBy(a => a))
            {
                Console.WriteLine(participant);
            }
        }
    }
}