using System;
using System.Linq;

public abstract class Harvester : Unit
{
    double oreOutput;
    double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get => oreOutput;
        protected set
        {
            Validator.CheckIsNegative(value, "Harvester", "OreOutput");
            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => energyRequirement;
        protected set
        {
            Validator.CheckIsNegative(value, "Harvester", "EnergyRequirement");
            Validator.CheckIsValueOverThan(value, 20000, "Harvester", "EnergyRequirement");
            energyRequirement = value;
        }
    }

    public string Type => string.Join("", this.GetType().ToString().SkipLast(9));

    public override string ToString()
    {
        return $"{Type} Harvester - {Id}" + Environment.NewLine +
            $"Ore Output: {OreOutput}" + Environment.NewLine +
            $"Energy Requirement: {EnergyRequirement}";
    }
}
