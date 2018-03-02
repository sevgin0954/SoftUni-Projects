public class Ferrari : ICar
{
    string model;
    string driverName;

    public string Model
    {
        get => model;
        set
        {
            model = value;
        }
    }

    public string DriverName
    {
        get => driverName;
        set
        {
            driverName = value;
        }
    }

    public string PushGas()
    {
        return "Zadu6avam sA!";
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }
}
