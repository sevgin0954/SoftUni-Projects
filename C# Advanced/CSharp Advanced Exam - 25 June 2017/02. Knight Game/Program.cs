using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[,] chessBoard = new char[n, n];

        ReadMatrix(chessBoard);

        bool isPiecefull = false;
        int removedKnightsCount = 0;

        while (isPiecefull == false)
        {
            int bestAttacksCount = 0;
            int mostAttacksRow = -1;
            int mostAttacksCol = -1;

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    if (chessBoard[row, col] == 'K')
                    {
                        int currentAttacksCount = CountPossibleKnigthAttacks(chessBoard, row, col);
                        if (currentAttacksCount > bestAttacksCount)
                        {
                            bestAttacksCount = currentAttacksCount;
                            mostAttacksRow = row;
                            mostAttacksCol = col;
                        }
                    }
                }
            }

                if (bestAttacksCount == 0)
            {
                isPiecefull = true;
            }
            else
            {
                chessBoard[mostAttacksRow, mostAttacksCol] = '0';
                removedKnightsCount++;
            }
        }

        Console.WriteLine(removedKnightsCount);
    }

    static void ReadMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string values = Console.ReadLine();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = values[col];
            }
        }
    }

    static int CountPossibleKnigthAttacks(char[,] chessBoard, int row, int col)
    {
        int attacksCount = 0;

        // try to move knight up
        if (row - 2 >= 0)
        {
            // try to move knight right
            if (col + 1 < chessBoard.GetLength(1))
            {
                if (chessBoard[row - 2, col + 1] == 'K')
                {
                    attacksCount++;
                }
            }

            // try to move knight left
            if (col - 1 >= 0)
            {
                if (chessBoard[row - 2, col - 1] == 'K')
                {
                    attacksCount++;
                }
            }
        }

        // try to move knight to down
        if (row + 2 < chessBoard.GetLength(0))
        {
            // try to move knight to right
            if (col + 1 < chessBoard.GetLength(1))
            {
                if (chessBoard[row + 2, col + 1] == 'K')
                {
                    attacksCount++;
                }
            }

            // try to move knight to left
            if (col - 1 >= 0)
            {
                if (chessBoard[row + 2, col - 1] == 'K')
                {
                    attacksCount++;
                }
            }
        }

        // try to move knight to right
        if (col + 2 < chessBoard.GetLength(1))
        {
            // try to move knight to up
            if (row - 1 >= 0)
            {
                if (chessBoard[row - 1, col + 2] == 'K')
                {
                    attacksCount++;
                }
            }
            // try to move knight to down
            if (row + 1 < chessBoard.GetLength(0))
            {
                if (chessBoard[row + 1, col + 2] == 'K')
                {
                    attacksCount++;
                }
            }
        }

        // try to move knight to left
        if (col - 2 >= 0)
        {
            // try to move knight to up
            if (row - 1 >= 0)
            {
                if (chessBoard[row - 1, col - 2] == 'K')
                {
                    attacksCount++;
                }
            }
            // try to move knight to down
            if (row + 1 < chessBoard.GetLength(0))
            {
                if (chessBoard[row + 1, col - 2] == 'K')
                {
                    attacksCount++;
                }
            }
        }

        return attacksCount;
    }
}