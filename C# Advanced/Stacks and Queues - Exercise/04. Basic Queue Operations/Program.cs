using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int addCount = int.Parse(input[0]);
        int removeCount = int.Parse(input[1]);
        int searchedNum = int.Parse(input[2]);

        int[] numsToPush = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        Queue<int> queue = new Queue<int>(numsToPush);

        for (int a = 0; a < removeCount; a++)
        {
            queue.Dequeue();
        }

        if (queue.Count == 0)
        {
            Console.WriteLine(0);
        }
        else if (queue.Any(n => n == searchedNum))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(queue.Min());
        }
    }
}