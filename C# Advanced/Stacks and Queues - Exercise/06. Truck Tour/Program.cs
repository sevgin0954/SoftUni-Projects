using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int startIndex = -1;
        int petrol = 0;
        bool isFirst = true;

        for (int index = 0; index < n; index++)
        {
            int[] petrolDistance = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            petrol += (petrolDistance[0] - petrolDistance[1]);
            if (petrol < 0)
            {
                petrol = 0;
                isFirst = true;
            }
            else if (isFirst)
            {
                isFirst = false;
                startIndex = index;
            }
        }

        Console.WriteLine(startIndex);
    }
}