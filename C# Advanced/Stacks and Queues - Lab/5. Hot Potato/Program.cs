using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] monstersNames = Console.ReadLine().Split();
        int n = int.Parse(Console.ReadLine());
        Queue<string> queue = new Queue<string>(monstersNames);

        while (queue.Count > 1)
        {
            for (int a = 1; a < n; a++)
            {
                queue.Enqueue(queue.Dequeue());
            }
            string mosterToRemove = queue.Dequeue();
            Console.WriteLine($"Removed {mosterToRemove}");
        }

        Console.WriteLine($"Last is {queue.Dequeue()}");
    }
}