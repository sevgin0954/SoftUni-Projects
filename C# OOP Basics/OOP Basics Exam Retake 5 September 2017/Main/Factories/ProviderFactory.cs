public static class ProviderFactory
{
    public static Provider Create(string[] args)
    {
        string type = args[0];
        string id = args[1];
        double energyOutput = double.Parse(args[2]);

        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);
            case "Pressure":
                return new PressureProvider(id, energyOutput);
            default:
                throw new System.ArgumentException();
        }
    }
}
