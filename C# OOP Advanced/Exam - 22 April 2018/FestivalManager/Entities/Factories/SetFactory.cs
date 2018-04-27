namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();

            Type typeInfo = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            ISet set = (ISet)Activator.CreateInstance(typeInfo, new object[] { name });

            return set;
		}
	}




}
