using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] rowsColsCount = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        for (int row = 0; row < rowsColsCount[0]; row++)
        {
            for (int col = 0; col < rowsColsCount[1]; col++)
            {
                // 97 ascii code for 'a'
                char firstAndLast = (char)(97 + row);
                char middle = (char)(97 + row + col);

                Console.Write($"{firstAndLast}{middle}{firstAndLast}");
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}