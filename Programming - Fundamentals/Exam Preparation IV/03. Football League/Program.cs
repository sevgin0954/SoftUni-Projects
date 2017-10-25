using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string key = Regex.Escape(Console.ReadLine());
        Dictionary<string, int[]> teamsScoresGoals = new Dictionary<string, int[]>();
        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "final")
            {
                break;
            }
            Match match = Regex.Match(input[2], @"\d+:\d+$");
            string[] scores = match.Value.Split(':');
            int team1Goals = int.Parse(scores[0]);
            int team2Goals = int.Parse(scores[1]);
            string team1Encrypted = input[0];
            string team2Encrypted = input[1];
            string patern = String.Format(@"(?<={0})[^\?\?]+(?={0})", key);
            Regex teamMatch = new Regex(patern);
            string team1 = teamMatch.Match(team1Encrypted).Value.ToUpper();
            string team2 = teamMatch.Match(team2Encrypted).Value.ToUpper();
            team1 = Reverse(team1);
            team2 = Reverse(team2);
            int team1Scores = 1;
            int team2Scores = 1;
            if (team1Goals > team2Goals)
            {
                team1Scores = 3;
                team2Scores = 0;
            }
            else if (team2Goals > team1Goals)
            {
                team2Scores = 3;
                team1Scores = 0;
            }
            if (teamsScoresGoals.ContainsKey(team1) == false)
            {
                teamsScoresGoals[team1] = new int[2];
            }
            if (teamsScoresGoals.ContainsKey(team2) == false)
            {
                teamsScoresGoals[team2] = new int[2];
            }
            teamsScoresGoals[team1][0] += team1Scores;
            teamsScoresGoals[team2][0] += team2Scores;
            teamsScoresGoals[team1][1] += team1Goals;
            teamsScoresGoals[team2][1] += team2Goals;
        }
        Console.WriteLine("League standings:");
            int place = 1;
        foreach (var teamScores in teamsScoresGoals.OrderBy(kvp => -kvp.Value[0]).ThenBy(kvp => kvp.Key))
        {
            Console.WriteLine($"{place++}. {teamScores.Key} {teamScores.Value[0]}");
        }
        Console.WriteLine("Top 3 scored goals:");
        int count = 0;
        foreach (var teamGoals in teamsScoresGoals.OrderBy(kvp => -kvp.Value[1]).ThenBy(kvp => kvp.Key))
        {
            Console.WriteLine($"- {teamGoals.Key} -> {teamGoals.Value[1]}");
            count++;
            if (count == 3)
            {
                break;
            }
        }
    }

    static string Reverse(string input)
    {
        char[] arr = input.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}