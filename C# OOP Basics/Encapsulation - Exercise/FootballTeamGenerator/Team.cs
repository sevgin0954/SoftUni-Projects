using System.Linq;
using System.Collections.Generic;

public class Team
{
    string name;
    List<Player> players = new List<Player>();

    public Team(string name)
    {
        Name = name;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<Player> Players => players;

    public float Rating => CalculateRating();

    public int CalculateRating()
    {
        if (players.Count == 0)
        {
            return 0;
        }

        float avgRating = players.Sum(p => p.Status.GetAverageStatus()) / players.Count;
        return System.Convert.ToInt32(avgRating);
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        if (players.Any(p => p.Name == playerName) == false)
        {
            throw new System.ArgumentException($"Player {playerName} is not in {Name} team.");
        }

        players.RemoveAll(p => p.Name == playerName);
    }
}