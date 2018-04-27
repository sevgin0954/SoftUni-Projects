using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder stringBuilder = new StringBuilder();

    public void AppendLine(string line)
    {
        stringBuilder.AppendLine(line);
    }

    public void WriteAllLines()
    {
        Console.WriteLine(stringBuilder.ToString().Trim());
    }
}