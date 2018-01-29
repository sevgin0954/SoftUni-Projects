using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        if (input.Length == 0)
        {
            return;
        }

        int[] nums = input
            .Split(" ".ToArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        Stack<int> stack = new Stack<int>(nums);

        Console.WriteLine(string.Join(" ", stack.ToArray()));
    }
}