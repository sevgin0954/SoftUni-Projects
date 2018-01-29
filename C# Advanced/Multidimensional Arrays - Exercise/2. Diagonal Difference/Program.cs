using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        ReadMatrix(matrix);

        int diagonalsRightSum = CalcDiagonalSum(matrix, "right");
        int diagonalLeftSum = CalcDiagonalSum(matrix, "left");

        Console.WriteLine(Math.Abs(diagonalsRightSum - diagonalLeftSum));

    }

    static void ReadMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] colValues = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = colValues[col];
            }
        }
    }

    static int CalcDiagonalSum(int[,] matrix, string direction)
    {
        int sum = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            if (direction == "right")
            {
                sum += matrix[row, row];
            }
            else
            {
                int startIndex = matrix.GetLength(1) - 1 - row;

                sum += matrix[row, startIndex];
            }
        }

        return sum;
    }
}