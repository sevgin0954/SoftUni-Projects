using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        List<int> evenNums = new List<int>();
        List<int> oddNums = new List<int>();

        Func<int, bool> isEven = n => n % 2 == 0;
        Action<int[]> print = ns => Console.Write(string.Join(" ", ns));

        for (int a = 0; a < nums.Length; a++)
        {
            if (isEven(nums[a]))
            {
                evenNums.Add(nums[a]);
            }
            else
            {
                oddNums.Add(nums[a]);
            }
        }

        evenNums.Sort();
        oddNums.Sort();

        nums = evenNums.Concat(oddNums).ToArray();

        print(nums);
    }
}