using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] rowsCols = Console.ReadLine()
            .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[,] matrix = new int[rowsCols[0], rowsCols[1]];

        ReadMatrix(matrix, rowsCols[0], rowsCols[1]);
        PrintBigestSubMatrix(matrix);
    }

    static void ReadMatrix(int[,] matrix, int rows, int cols)
    {
        for (int row = 0; row < rows; row++)
        {
            int[] values = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = values[col];
            }
        }
    }

    static void PrintBigestSubMatrix(int[,] matrix)
    {
        int startRow = 0;
        int startCol = 0;
        int biggestSum = int.MinValue;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int currentSum = 0;

                currentSum += matrix[row, col] + matrix[row, col + 1];
                currentSum += matrix[row + 1, col] + matrix[row + 1, col + 1];

                if (currentSum > biggestSum)
                {
                    biggestSum = currentSum;
                    startRow = row;
                    startCol = col;
                }
            }
        }

        Console.WriteLine(matrix[startRow, startCol] + " " + matrix[startRow, startCol + 1]);
        Console.WriteLine(matrix[startRow + 1, startCol] + " " + matrix[startRow + 1, startCol + 1]);
        Console.WriteLine(biggestSum);
    }
}