using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Team> teams = ReadTeams(n);
        AddMembers(teams);
        List<Team> disbandTeams = teams.Where(t => t.MemebersNames == null).ToList();
        teams = teams.Where(t => t.MemebersNames != null).ToList();
        PrintTeams(teams);
        Console.WriteLine($"Teams to disband:");
        if (disbandTeams.Count > 0)
        {
            foreach (Team team in disbandTeams.OrderBy(a => a.Name))
            {
                Console.WriteLine($"{team.Name}");
            }
        }
    }

    static List<Team> ReadTeams(int count)
    {
        List<Team> teams = new List<Team>();
        for (int a = 0; a < count; a++)
        {
            string[] input = Console.ReadLine().Split('-');
            if (teams.Any(t => t.Name == input[1]))
            {
                Console.WriteLine($"Team {input[1]} was already created!");
                continue;
            }
            if (teams.Any(t => t.LiderName == input[0]))
            {
                Console.WriteLine($"{input[0]} cannot create another team!");
                continue;
            }
            Team team = new Team
            {
                Name = input[1],
                LiderName = input[0]
            };
            teams.Add(team);
            Console.WriteLine($"Team {input[1]} has been created by {input[0]}!");
        }
        return teams;
    }

    static void AddMembers(List<Team> teams)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end of assignment")
            {
                break;
            }
            string member = input.Substring(0, input.IndexOf("->"));
            string teamName = input.Substring(input.IndexOf("->") + 2);
            if (!teams.Any(t => t.Name == teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist!");
                continue;
            }
            if (teams.Any(t => t.LiderName == member))
            {
                Console.WriteLine($"Member {member} cannot join team {teamName}!");
                continue;
            }
            if (teams.Any(t => t.MemebersNames != null && t.MemebersNames.Any(a => a == member)))
            {
                Console.WriteLine($"Member {member} cannot join team {teamName}!");
                continue;
            }
            Team exitingTeam = teams.First(t => t.Name == teamName);
            if (exitingTeam.MemebersNames == null)
            {
                exitingTeam.MemebersNames = new List<string>();
            }
            exitingTeam.MemebersNames.Add(member);
        }
    }

    static void PrintTeams(List<Team> disbandTeams)
    {
        foreach (Team team in disbandTeams.OrderByDescending(t => t.MemebersNames.Count).ThenBy(t => t.Name))
        {
            Console.WriteLine($"{team.Name}");
            Console.WriteLine($"- {team.LiderName}");
            foreach (string name in team.MemebersNames.OrderBy(n => n))
            {
                Console.WriteLine($"-- {name}");
            }
        }   
    }
}

class Team
{
    public string Name { get; set; }
    public string LiderName { get; set; }
    public List<string> MemebersNames { get; set; }
}