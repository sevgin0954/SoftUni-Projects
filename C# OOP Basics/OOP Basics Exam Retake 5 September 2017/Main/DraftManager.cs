using System;
using System.Linq;
using System.Collections.Generic;
public class DraftManager
{
    ModeType currentMode = ModeType.FullMode;
    double totalStoredEnergy = 0;
    double totalMinedOre = 0;
    Dictionary<string, Provider> idsProviders = new Dictionary<string, Provider>();
    Dictionary<string, Harvester> idsHarvesters = new Dictionary<string, Harvester>();

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = HarvesterFactory.Create(arguments.ToArray());
            idsHarvesters[arguments[1]] = harvester;

            return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider provider = ProviderFactory.Create(arguments.ToArray());
            idsProviders[arguments[1]] = provider;

            return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string Day()
    {
        double providersDayEnergy = idsProviders.Sum(p => p.Value.EnergyOutput);
        totalStoredEnergy += providersDayEnergy;
        double harvastersRequiredEnergy = idsHarvesters.Sum(h => h.Value.EnergyRequirement);
        double dayMinedOreo = idsHarvesters.Sum(h => h.Value.OreOutput);

        switch (currentMode)
        {
            case ModeType.HalfMode:
                harvastersRequiredEnergy *= 0.6;
                dayMinedOreo *= 0.5;
                break;
            case ModeType.EnergyMode:
                harvastersRequiredEnergy = 0;
                dayMinedOreo = 0;
                break;
        }

        if (totalStoredEnergy >= harvastersRequiredEnergy)
        {
            totalStoredEnergy -= harvastersRequiredEnergy;
            totalMinedOre += dayMinedOreo;
        }
        else
        {
            dayMinedOreo = 0;
        }

        return $"A day has passed." + Environment.NewLine +
            $"Energy Provided: {providersDayEnergy}" + Environment.NewLine +
            $"Plumbus Ore Mined: {dayMinedOreo}";
    }

    public string Mode(List<string> arguments)
    {
        string mode = arguments[0];

        switch (mode)
        {
            case "Full":
                currentMode = ModeType.FullMode;
                break;
            case "Half":
                currentMode = ModeType.HalfMode;
                break;
            case "Energy":
                currentMode = ModeType.EnergyMode;
                break;
        }

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string searchedId = arguments[0];

        if (idsProviders.ContainsKey(searchedId))
        {
            return idsProviders[searchedId].ToString();
        }
        else if (idsHarvesters.ContainsKey(searchedId))
        {
            return idsHarvesters[searchedId].ToString();
        }
        else
        {
            return $"No element found with id - {searchedId}";
        }
    }

    public string ShutDown()
    {
        return $"System Shutdown" + Environment.NewLine +
            $"Total Energy Stored: {totalStoredEnergy}" + Environment.NewLine +
            $"Total Mined Plumbus Ore: {totalMinedOre}";
    }
}
