using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int len = int.Parse(Console.ReadLine());
        int[] field = new int[len];
        int[] bugsIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        AddBugsToField(field, bugsIndexes);
        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "end")
            {
                break;
            }
            int bugIndex = int.Parse(input[0]);
            string direction = input[1];
            int flyLen = int.Parse(input[2]);
            if (bugIndex < 0 || bugIndex >= field.Length || field[bugIndex] == 0)
            {
                continue;
            }
            field[bugIndex] = 0;
            MoveBug(field, bugIndex, flyLen, direction);
        }
        Console.Write(string.Join(" ", field));
    }

    static void AddBugsToField(int[] field, int[] bugsPositions)
    {
        for (int a = 0; a < bugsPositions.Length; a++)
        {
            int index = bugsPositions[a];
            if (index < field.Length && index >= 0)
            {
                field[index] = 1;
            }
        }
    }

    static void MoveBug(int[] field, int bugIndex, int flyLen, string direction)
    {
        while (true)
        {
            if (direction == "right")
            {
                bugIndex += flyLen;
            }
            else
            {
                bugIndex -= flyLen;
            }
            if (bugIndex >= field.Length || bugIndex < 0)
            {
                return;
            }
            if (field[bugIndex] == 0)
            {
                field[bugIndex] = 1;
                return;
            }
        }
    }
}