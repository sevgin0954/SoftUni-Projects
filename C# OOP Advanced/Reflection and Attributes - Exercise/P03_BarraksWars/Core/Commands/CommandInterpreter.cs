using _03BarracksFactory.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace P03_BarraksWars.Core.Commands
{
    class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type type = assembly
                .GetTypes()
                .Where(t => t.Name.ToLower() == commandName.ToLower() + "command")
                .FirstOrDefault();

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            FieldInfo[] fieldsToInjects = type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
                .ToArray();

            object[] injectArgs = fieldsToInjects.Select(f => serviceProvider.GetService(f.FieldType)).ToArray();

            object[] constructorArgs = new object[] { data }.Concat(injectArgs).ToArray();

            ICommand command = (ICommand)Activator.CreateInstance(type, constructorArgs);

            return command;
        }
    }
}
