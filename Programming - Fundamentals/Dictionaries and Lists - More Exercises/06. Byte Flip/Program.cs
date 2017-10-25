using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] arr = Console.ReadLine().Split();
        arr = arr.Where(n => n.Length == 2).ToArray();
        arr = arr.Select(n => String.Join("", n.Reverse().ToArray())).ToArray();
        arr = arr.Reverse().ToArray();
        char[] decoded = arr.Select(a => (char)Convert.ToInt32(a, 16)).ToArray();
        Console.WriteLine(String.Join("", decoded));
    }
}