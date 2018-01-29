using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int allowedCarsToPass = int.Parse(Console.ReadLine());
        int totalCarsPassed = 0;
        Queue<string> carsQueue = new Queue<string>();

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "end")
            {
                break;
            }
            else if (command == "green")
            {
                for (int a = 0; a < allowedCarsToPass; a++)
                {
                    if (carsQueue.Count == 0)
                    {
                        break;
                    }
                    string passedCarName = carsQueue.Dequeue();
                    totalCarsPassed++;
                    Console.WriteLine($"{passedCarName} passed!");
                }
            }
            else
            {
                carsQueue.Enqueue(command);
            }
        }

        Console.WriteLine(totalCarsPassed + " cars passed the crossroads.");
    }
}