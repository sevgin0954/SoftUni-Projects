public abstract class Unit
{
    string id;

    protected Unit(string id)
    {
        Id = id;
    }

    public string Id
    {
        get => id;
        set { id = value; }
    }
}
