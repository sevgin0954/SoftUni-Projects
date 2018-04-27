using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type type = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == ammunitionName);

        object[] constructorParams = new object[] { };
        IAmmunition amunition = (IAmmunition)Activator.CreateInstance(type, constructorParams);

        return amunition;
    }
}