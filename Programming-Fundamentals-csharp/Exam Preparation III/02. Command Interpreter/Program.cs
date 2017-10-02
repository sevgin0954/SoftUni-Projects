using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "end")
            {
                break;
            }
            if (input[0] == "reverse" || input[0] == "sort")
            {
                int startIndex = int.Parse(input[2]);
                int count = int.Parse(input[4]);
                if (startIndex < 0 || startIndex >= arr.Count || startIndex + count > arr.Count || count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                    continue;
                }
                if (input[0] == "reverse")
                {
                    arr.Reverse(startIndex, count);
                }
                else
                {
                    arr.Sort(startIndex, count, null);
                }
            }
            if (input[0] == "rollLeft" || input[0] == "rollRight")
            {
                int count = int.Parse(input[1]);
                if (count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                    continue;
                }
                count %= arr.Count;
                if (input[0] == "rollLeft")
                {
                    RollArr(arr, count, "left");
                }
                else
                {
                    RollArr(arr, count, "right");
                }
            }
        }
        Console.Write("[");
        Console.Write(string.Join(", ", arr));
        Console.Write("]");
    }

    static void RollArr(List<string> arr, int count, string position)
    {
        for (int a = 0; a < count; a++)
        {
            if (position == "left")
            {
                string firstElement = arr[0];
                arr.RemoveAt(0);
                arr.Add(firstElement);
            }
            else if (position == "right")
            {
                string lastElement = arr[arr.Count - 1];
                arr.RemoveAt(arr.Count - 1);
                arr.Insert(0, lastElement);
            }
        }
    }
}