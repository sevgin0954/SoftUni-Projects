namespace _03BarracksFactory.Contracts
{
    public interface ICommandInterpreter
    {
        ICommand InterpretCommand(string[] data, string commandName);
    }
}
