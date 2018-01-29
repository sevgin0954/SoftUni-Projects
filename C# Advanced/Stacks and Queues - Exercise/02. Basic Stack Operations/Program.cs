using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int pushCount = input[0];
        int popCount = input[1];
        int searchedNum = input[2];

        int[] numsInStack = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Stack<int> stack = new Stack<int>(numsInStack);

        for (int a = 0; a < popCount; a++)
        {
            stack.Pop();
        }

        if (stack.Count == 0)
        {
            Console.WriteLine(0);
        }
        else if (stack.Any(n => n == searchedNum))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(stack.Min(n => n));
        }

    }
}