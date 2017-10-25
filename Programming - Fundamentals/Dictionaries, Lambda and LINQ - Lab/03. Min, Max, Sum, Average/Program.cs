using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] nums = new int[n];
        for (int a = 0; a < n; a++)
        {
            nums[a] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Sum = " + nums.Sum());
        Console.WriteLine("Min = " + nums.Min());
        Console.WriteLine("Max = " + nums.Max());
        Console.WriteLine("Average = " + nums.Average());
    }
}