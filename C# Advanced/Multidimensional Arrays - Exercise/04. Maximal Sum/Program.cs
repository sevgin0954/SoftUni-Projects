using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] rowsColsCount = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[,] matrix = new int[rowsColsCount[0], rowsColsCount[1]];

        ReadMatrix(matrix, rowsColsCount[0], rowsColsCount[1]);

        int startRowIndex = 0;
        int startColIndex = 0;
        int bestSum = int.MinValue;

        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int fistRowSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                int secondRowSum = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                int thirdRowSum = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                int totalSum = fistRowSum + secondRowSum + thirdRowSum;
                if (totalSum > bestSum)
                {
                    bestSum = totalSum;
                    startRowIndex = row;
                    startColIndex = col;
                }
            }
        }

        Console.WriteLine($"Sum = {bestSum}");
        Console.WriteLine($"{matrix[startRowIndex, startColIndex]} {matrix[startRowIndex, startColIndex + 1]} {matrix[startRowIndex, startColIndex + 2]}");
        Console.WriteLine($"{matrix[startRowIndex + 1, startColIndex]} {matrix[startRowIndex + 1, startColIndex + 1]} {matrix[startRowIndex + 1, startColIndex + 2]}");
        Console.WriteLine($"{matrix[startRowIndex + 2, startColIndex]} {matrix[startRowIndex + 2, startColIndex + 1]} {matrix[startRowIndex + 2, startColIndex + 2]}");
    }

    static void ReadMatrix(int[,] matrix, int rowsCount, int colsCount)
    {
        for (int row = 0; row < rowsCount; row++)
        {
            int[] colValues = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < colsCount; col++)
            {
                matrix[row, col] = colValues[col];
            }
        }
    }
}