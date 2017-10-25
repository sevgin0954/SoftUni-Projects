using System;

class Program
{
    static void Main()
    {
        string[] time = Console.ReadLine().Split(':');
        long stepCount = long.Parse(Console.ReadLine());
        long secondsPerStet = long.Parse(Console.ReadLine());
        long totalSeconds = stepCount * secondsPerStet;
        long currentHour = long.Parse(time[0]);
        long currentMin = long.Parse(time[1]);
        long currentSec = long.Parse(time[2]);
        long timeInSec = currentHour * 3600 + currentMin * 60 + currentSec + totalSeconds;
        long hh = (timeInSec / 3600) % 24;
        long mm = timeInSec % 3600 / 60;
        long ss = timeInSec % 3600 % 60;
        Console.Write($"Time Arrival: {hh:d2}:{mm:d2}:{ss:d2}");
    }
}