public class Status
{
    byte endurance;
    byte sprint;
    byte dribble;
    byte passing;
    byte shooting;

    public Status(byte endurance, byte sprint, byte dribble, byte passing, byte shooting)
    {
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    public byte Endurance
    {
        get { return endurance; }
        set
        {
            ValidateStatus.ValidateData(value, "Endurance");
            endurance = value;
        }
    }

    public byte Sprint
    {
        get { return sprint; }
        set
        {
            ValidateStatus.ValidateData(value, "Sprint");
            sprint = value;
        }
    }

    public byte Dribble
    {
        get { return dribble; }
        set
        {
            ValidateStatus.ValidateData(value, "Dribble");
            dribble = value;
        }
    }

    public byte Passing
    {
        get { return passing; }
        set
        {
            ValidateStatus.ValidateData(value, "Passing");
            passing = value;
        }
    }

    public byte Shooting
    {
        get { return shooting; }
        set
        {
            ValidateStatus.ValidateData(value, "Shooting");
            shooting = value;
        }
    }

    public float GetAverageStatus()
    {
        return (Endurance + Sprint + Dribble + Passing + Shooting) / (float)5;
    }
}