using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int rowsCount = int.Parse(Console.ReadLine());
        int[][] jagArrLeft = new int[rowsCount][];
        int[][] jagArrRight = new int[rowsCount][];

        ReadJagedArray(jagArrLeft);
        ReadJagedArray(jagArrRight);

        if (IsFit(jagArrLeft, jagArrRight))
        {
            ReverseJagArr(jagArrRight);
            PrintJagArrsAsMatrix(jagArrLeft, jagArrRight);
        }
        else
        {
            Console.Write("The total number of cells is: ");
            Console.WriteLine(CountElements(jagArrLeft) + CountElements(jagArrRight));
        }
    }

    static void ReadJagedArray(int[][] jagArr)
    {
        for (int row = 0; row < jagArr.GetLength(0); row++)
        {
            jagArr[row] = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }

    static bool IsFit(int[][] jagArrLeft,int[][] jagArrRight)
    {
        bool isFit = true;
        int firstRowLen = jagArrLeft[0].Length + jagArrRight[0].Length;

        for (int row = 1; row < jagArrLeft.GetLength(0); row++)
        {
            int currentColLen = jagArrLeft[row].Length + jagArrRight[row].Length;
            if (currentColLen != firstRowLen)
            {
                isFit = false;
                break;
            }
        }

        return isFit;
    }

    static void PrintJagArrsAsMatrix(int[][] jagArrLeft, int[][] jagArrRight)
    {
        for (int row = 0; row < jagArrRight.GetLength(0); row++)
        {
            Console.Write("[");
            Console.Write(string.Join(", ", jagArrLeft[row]));
            Console.Write(", ");
            Console.Write(string.Join(", ", jagArrRight[row]));
            Console.WriteLine("]");
        }
    }

    static int CountElements(int[][] jagArr)
    {
        int count = 0;

        for (int row = 0; row < jagArr.GetLength(0); row++)
        {
            count += jagArr[row].Length;
        }

        return count;
    }

    static void ReverseJagArr(int[][] jagArr)
    {
        for (int row = 0; row < jagArr.GetLength(0); row++)
        {
            jagArr[row] = jagArr[row].Reverse().ToArray();
        }
    }
}