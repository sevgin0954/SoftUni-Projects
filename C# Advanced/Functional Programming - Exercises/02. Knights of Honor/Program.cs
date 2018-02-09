using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string names = Console.ReadLine();
        Action<string> addSirToNames = (s) => Console.Write(string.Join(Environment.NewLine, s.Split(' ').Select(name => "Sir " + name)));

        addSirToNames(names);
    }
}