using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        nums = nums.Where(n => n % 2 == 0).ToArray();
        double avg = nums.Average();
        for (int a = 0; a < nums.Length; a++)
        {
            if (nums[a] > avg)
            {
                nums[a] += 1;
            }
            else
            {
                nums[a] -= 1;
            }
        }
        Console.Write(String.Join(" ", nums));
    }
}