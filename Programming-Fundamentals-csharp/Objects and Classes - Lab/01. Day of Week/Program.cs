﻿using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
        DateTime date = new DateTime(input[2], input[1], input[0]);
        Console.WriteLine(date.DayOfWeek);
    }
}