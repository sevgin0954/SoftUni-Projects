using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine()
            .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[,] matrix = new int[3, nums.Length];

        int[] firstEmptyIndexes = new int[3];


        for (int a = 0; a < nums.Length; a++)
        {
            int rest = Math.Abs(nums[a]) % 3;
            int firstEmptyIndex = firstEmptyIndexes[rest]++;
            matrix[rest, firstEmptyIndex] = nums[a];
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (firstEmptyIndexes[row] <= col)
                {
                    break;
                }
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}