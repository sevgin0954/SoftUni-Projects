using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<long> arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        List<long> removedNums = new List<long>();
        while (arr.Count > 0)
        {
            long removedNum = 0;
            int index = int.Parse(Console.ReadLine());
            if (index < 0)
            {
                removedNum = arr[0];
                arr[0] = arr[arr.Count - 1];
            }
            else if (index >= arr.Count)
            {
                removedNum = arr[arr.Count - 1];
                arr[arr.Count - 1] = arr[0];
            }
            else
            {
                removedNum = arr[index];
                arr.RemoveAt(index);
            }
            arr = arr.Select(n => n <= removedNum ? n += removedNum : n -= removedNum).ToList();
            removedNums.Add(removedNum);
        }
        Console.Write(removedNums.Sum());
    }
}