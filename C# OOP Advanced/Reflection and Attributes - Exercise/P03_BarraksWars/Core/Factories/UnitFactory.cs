namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type type = assembly
                .GetTypes()
                .Where(t => t.Name == unitType)
                .FirstOrDefault();

            if (type == null)
            {
                throw new InvalidOperationException($"{unitType} dont exist");
            }

            if (typeof(IUnit).IsAssignableFrom(type) == false)
            {
                throw new InvalidOperationException($"{type.Name} is not IUnit");
            }

            IUnit unit = (IUnit)Activator.CreateInstance(type);

            return unit;
        }
    }
}
