public class Robot : IIdentity
{
    string model;
    string id;

    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }

    public string Model
    {
        get => model;
        set
        {
            model = value;
        }
    }

    public string Id
    {
        get => id;
        set
        {
            id = value;
        }
    }
}