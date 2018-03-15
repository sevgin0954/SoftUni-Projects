public static class HarvesterFactory
{
    public static Harvester Create(string[] args)
    {
        string type = args[0];
        string id = args[1];
        double oreOutput = double.Parse(args[2]);
        double energyRequirement = double.Parse(args[3]);

        switch (type)
        {
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);
            case "Sonic":
                int sonicFactor = int.Parse(args[4]);
                return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
            default:
                throw new System.ArgumentException();
        }
    }
}