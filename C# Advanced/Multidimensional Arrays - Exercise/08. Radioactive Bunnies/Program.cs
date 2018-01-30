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
        string command = Console.ReadLine();
        int[] playerPosition = FindCharOf(matrix, 'P');
        bool isPlayerDead = false;
        bool isPlayerWon = false;

        for (int a = 0; a < command.Length; a++)
        {
            int[] nextPlayerPosition = (int[])playerPosition.Clone();

            // Check is bunny step on the player
            if (matrix[playerPosition[0], playerPosition[1]] != 'P')
            {
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {playerPosition[0]} {playerPosition[1]}");
                return;
            }
            else
            {
                switch (command[a])
                {
                    case 'R':
                        nextPlayerPosition[1]++;
                        break;
                    case 'D':
                        nextPlayerPosition[0]++;
                        break;
                    case 'L':
                        nextPlayerPosition[1]--;
                        break;
                    case 'U':
                        nextPlayerPosition[0]--;
                        break;
                }

                // Check is player out of matrix
                if (nextPlayerPosition[0] >= rowsColsCount[0] || nextPlayerPosition[0] < 0 || nextPlayerPosition[1] >= rowsColsCount[1] || nextPlayerPosition[1] < 0)
                {
                    isPlayerWon = true;
                }
                // Check is next block free
                else if (matrix[nextPlayerPosition[0], nextPlayerPosition[1]] != '.')
                {
                    isPlayerDead = true;
                }

                matrix[playerPosition[0], playerPosition[1]] = '.';
            }

            if (isPlayerDead)
            {
                matrix = SpreadBunnies(matrix);
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {nextPlayerPosition[0]} {nextPlayerPosition[1]}");
                break;
            }
            else if (isPlayerWon)
            {
                matrix = SpreadBunnies(matrix);
                PrintMatrix(matrix);
                matrix[playerPosition[0], playerPosition[1]] = '.';
                Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");
                break;
            }
            else
            {
                matrix[nextPlayerPosition[0], nextPlayerPosition[1]] = 'P';
                playerPosition = (int[])nextPlayerPosition.Clone();
                matrix = SpreadBunnies(matrix);
            }
        }
    }

    static void ReadMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] values = Console.ReadLine().ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = values[col];
            }
        }
    }

    static int[] FindCharOf(char[,] matrix, char searched)
    {
        int[] rowCol = { -1, -1 };

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == searched)
                {
                    rowCol[0] = row;
                    rowCol[1] = col;
                    break;
                }
            }
        }

        return rowCol;
    }

    static char[,] SpreadBunnies(char[,] matrix)
    {
        char[,] tempMatrix = (char[,])matrix.Clone();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'B')
                {
                    if (row < matrix.GetLength(0) - 1)
                    {
                        tempMatrix[row + 1, col] = 'B';
                    }
                    if (row > 0)
                    {
                        tempMatrix[row - 1, col] = 'B';
                    }
                    if (col < matrix.GetLength(1) - 1)
                    {
                        tempMatrix[row, col + 1] = 'B';
                    }
                    if (col > 0)
                    {
                        tempMatrix[row, col - 1] = 'B';
                    }
                }
            }
        }

        return tempMatrix;
    }

    static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}