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

        Console.WriteLine(matrix.GetLength(0));
        Console.WriteLine(matrix.GetLength(1));
        Console.WriteLine(SumMatrix(matrix));

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

    static int SumMatrix(int[,] matrix)
    {
        int totalSum = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                totalSum += matrix[row, col];
            }
        }

        return totalSum;
    }
}