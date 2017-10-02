using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<DateTime> times = Console.ReadLine().Split().Select(DateTime.Parse).ToList();
        times.Sort();
        bool isFirst = true;
        foreach (DateTime time in times)
        {
            if (isFirst == false)
            {
                Console.Write(", ");
            }
            isFirst = false;
            Console.Write($"{time.Hour:d2}:{time.Minute:d2}");
        }
    }
}