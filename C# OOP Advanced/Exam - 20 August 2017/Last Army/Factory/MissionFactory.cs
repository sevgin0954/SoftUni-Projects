using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type type = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == difficultyLevel);

        object[] constructorParams = new object[] { neededPoints };
        IMission mission = (IMission)Activator.CreateInstance(type, constructorParams);

        return mission;
    }
}