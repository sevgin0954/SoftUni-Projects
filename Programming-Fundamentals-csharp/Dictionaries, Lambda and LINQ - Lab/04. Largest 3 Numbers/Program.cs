using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] first3 = nums.OrderBy(n => -n).Take(3).ToArray();
        Console.Write(String.Join(" ", first3));
    }
}