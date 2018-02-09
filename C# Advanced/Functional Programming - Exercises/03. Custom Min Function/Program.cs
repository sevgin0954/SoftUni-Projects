using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        Func<int[], int> getSmallestNum = (numbers) => numbers.Min();

        Console.WriteLine(getSmallestNum(nums));
    }
}