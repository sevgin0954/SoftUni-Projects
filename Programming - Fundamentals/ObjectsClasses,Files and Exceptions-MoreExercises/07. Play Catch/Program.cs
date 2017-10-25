using System;
using System.Linq;

class Program
{
    static int exseptionCount = 0;
    static void Main()
    {
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        while (exseptionCount != 3)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "Replace")
            {
                try
                {
                    int index = int.Parse(input[1]);
                    int num = int.Parse(input[2]);
                    Replace(nums, index, num);
                }
                catch (FormatException)
                {
                    exseptionCount++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }
            else if (input[0] == "Print")
            {
                try
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    Print(nums, startIndex, endIndex);
                }
                catch (FormatException)
                {
                    exseptionCount++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }
            else if (input[0] == "Show")
            {
                try
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(nums[index]);
                }
                catch (FormatException)
                {
                    exseptionCount++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
                catch (IndexOutOfRangeException)
                {
                    exseptionCount++;
                    Console.WriteLine("The index does not exist!");
                }
            }
        }
        Print(nums, 0, nums.Length - 1);
    }

    static void Replace(int[] nums, int index, int num)
    {
        try
        {
            nums[index] = num;
        }
        catch (IndexOutOfRangeException)
        {
            exseptionCount++;
            Console.WriteLine("The index does not exist!");
        }
    }

    static void Print(int[] nums, int startIndex, int endIndex)
    {
        try
        {
            int temp = nums[startIndex];
            temp = nums[endIndex];
            bool isFirst = true;
            for (int index = startIndex; index <= endIndex; index++)
            {
                if (!isFirst)
                {
                    Console.Write(", ");
                }
                isFirst = false;
                Console.Write(nums[index]);
            }
            Console.WriteLine();
        }
        catch (IndexOutOfRangeException)
        {
            exseptionCount++;
            Console.WriteLine("The index does not exist!");
        }
    }
}