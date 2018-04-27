using System;

public class Engine
{
    private IWriter consoleWriter;
    private IReader consoleReader;

    public Engine(IWriter consoleWriter, IReader consoleReader)
    {
        this.consoleWriter = consoleWriter;
        this.consoleReader = consoleReader;
    }

    public void Run()
    {
        var input = consoleReader.ReadLine();
        var gameController = new GameController(consoleWriter);

        while (input.Equals("Enough! Pull back!") == false)
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                consoleWriter.AppendLine(arg.Message);
            }
            input = consoleReader.ReadLine();
        }

        gameController.RequestResult();
        consoleWriter.WriteAllLines();
    }
}