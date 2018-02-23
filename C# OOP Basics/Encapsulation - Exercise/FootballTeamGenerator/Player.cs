using System.Linq;

public class Player
{
    string name;
    Status status;

    public Player(string name, Status status)
    {
        Name = name;
        Status = status;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Status Status
    {
        get { return status; }
        set { status = value; }
    }
}
