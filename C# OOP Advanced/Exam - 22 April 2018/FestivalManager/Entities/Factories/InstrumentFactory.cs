namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();

            Type typeInfo = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            IInstrument instrument = (IInstrument)Activator.CreateInstance(typeInfo, new object[] { });

            return instrument;
        }
	}
}