using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        int[] stones = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Lake lake = new Lake(stones);

        Console.WriteLine(string.Join(", ", lake));
    }
}
    
