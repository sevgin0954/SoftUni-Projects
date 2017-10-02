using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] left = nums.Take(nums.Length / 4).Reverse().ToArray();
        int[] right = nums.Skip(nums.Length - nums.Length / 4).Reverse().ToArray();
        nums = nums.Skip(nums.Length / 4).Take(nums.Length / 2).ToArray();
        int[] sides = left.Concat(right).ToArray();
        var sum = nums.Select((x, index) => x + sides[index]);
        Console.Write(String.Join(" ", sum));
    }
}