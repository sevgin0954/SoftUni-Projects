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

        char[,] matrix = new char[rowsColsCount[0], rowsColsCount[1]];

        ReadMatrix(matrix);
        Console.WriteLine(CountAllEqualsSubMatrix(matrix));

    }

    static void ReadMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] colValues = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(Convert.ToChar)
                .ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = colValues[col];
            }
        }
    }

    static int CountAllEqualsSubMatrix(char[,] matrix)
    {
        int equalSubMatrixesCount = 0;

        for (int row = 1; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                char upLeft = matrix[row - 1, col];
                char upRight = matrix[row - 1, col + 1];
                char downLeft = matrix[row, col];
                char downRight = matrix[row, col + 1];

                if (upLeft == upRight && upRight == downLeft && downLeft == downRight)
                {
                    equalSubMatrixesCount++;
                }
            }
        }

        return equalSubMatrixesCount;
    }
}