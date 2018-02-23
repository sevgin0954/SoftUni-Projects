using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        Dictionary<string, Team> teamNamesTeams = new Dictionary<string, Team>();

        while (true)
        {
            string[] input = Console.ReadLine().Split(';');
            if (input[0] == "END")
            {
                break;
            }

            try
            {
                switch (input[0])
                {
                    case "Team":
                        AddTeam(teamNamesTeams, input);
                        break;
                    case "Add":
                        AddPlayerToTeam(teamNamesTeams, input);
                        break;
                    case "Remove":
                        RemovePlayerFromTeam(teamNamesTeams, input);
                        break;
                    case "Rating":
                        PrintTeamRating(teamNamesTeams, input);
                        break;
                }
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }

    private static void AddTeam(Dictionary<string, Team> teamNamesTeams, string[] input)
    {
        string teamName = input[1];
        Team team = new Team(teamName);

        teamNamesTeams[teamName] = team;
    }

    private static void AddPlayerToTeam(Dictionary<string, Team> teamNamesTeams, string[] input)
    {
        string teamName = input[1];
        string playerName = input[2];
        byte endurance = byte.Parse(input[3]);
        byte sprint = byte.Parse(input[4]);
        byte dribble = byte.Parse(input[5]);
        byte passing = byte.Parse(input[6]);
        byte shooting = byte.Parse(input[7]);

        if (teamNamesTeams.ContainsKey(teamName) == false)
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }

        Status status = new Status(endurance, sprint, dribble, passing, shooting);
        Player playerToAdd = new Player(playerName, status);

        teamNamesTeams[teamName].AddPlayer(playerToAdd);
    }

    private static void RemovePlayerFromTeam(Dictionary<string, Team> teamNamesTeams, string[] input)
    {
        string teamName = input[1];
        string playerName = input[2];

        teamNamesTeams[teamName].RemovePlayer(playerName);
    }

    private static void PrintTeamRating(Dictionary<string, Team> teamNamesTeams, string[] input)
    {
        string teamName = input[1];

        if (teamNamesTeams.ContainsKey(teamName) == false)
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }

        Console.WriteLine($"{teamName} - {teamNamesTeams[teamName].CalculateRating()}");
    }
}
