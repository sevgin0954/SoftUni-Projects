using System;

class Program
{
    static void Main()
    {
        int daysCount = int.Parse(Console.ReadLine());
        int runnersCount = int.Parse(Console.ReadLine());
        int avgLaps = int.Parse(Console.ReadLine());
        int trackLen = int.Parse(Console.ReadLine());
        int trackCapacity = int.Parse(Console.ReadLine());
        decimal moneyPerKm = decimal.Parse(Console.ReadLine());
        if (runnersCount > trackCapacity * daysCount)
        {
            runnersCount = trackCapacity * daysCount;
        }
        long totalLaps = (long)runnersCount * avgLaps;
        long totalKm = totalLaps * trackLen;
        decimal moneyRaised = totalKm * moneyPerKm / 1000;
        Console.Write($"Money raised: {moneyRaised:f2}");
    }
}