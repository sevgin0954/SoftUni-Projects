using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] driversNames = Console.ReadLine().Split();
        double[] path = Console.ReadLine().Split().Select(double.Parse).ToArray();
        long[] checkpoints = Console.ReadLine().Split().Select(long.Parse).ToArray();
        for (int a = 0; a < driversNames.Length; a++)
        {
            CalcDriverReach(driversNames[a], path, checkpoints);
        }
    }

    static void CalcDriverReach(string driverName, double[] path, long[] checkpoints)
    {
        double fuel = driverName[0];
        for (int a = 0; a < path.Length; a++)
        {
            if (checkpoints.Contains(a))
            {
                fuel += path[a];
            }
            else
            {
                fuel -= path[a];
            }
            if (fuel <= 0)
            {
                Console.WriteLine($"{driverName} - reached {a}");
                return;
            }
        }
        Console.WriteLine($"{driverName} - fuel left {fuel:f2}");
    }
}