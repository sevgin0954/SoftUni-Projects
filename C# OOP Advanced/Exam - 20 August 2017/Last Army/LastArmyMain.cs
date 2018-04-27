public class LastArmyMain
{
    public static void Main()
    {
        IWriter writer = new ConsoleWriter();
        IReader reader = new ConsoleReader();
        Engine engine = new Engine(writer, reader);

        engine.Run();
    }
}