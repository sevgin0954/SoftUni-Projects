using System;
using System.Linq;

public abstract class Provider : Unit
{
    double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get => energyOutput;
        protected set
        {
            Validator.CheckIsNegative(value, "Provider", "EnergyOutput");
            Validator.CheckIsValueLessThan(value, 10000, "Provider", "EnergyOutput");
            energyOutput = value;
        }
    }

    public string Type => string.Join("", this.GetType().ToString().SkipLast(8));

    public override string ToString()
    {
        return $"{Type} Provider - {Id}" + Environment.NewLine +
            $"Energy Output: {EnergyOutput}";
    }
}
