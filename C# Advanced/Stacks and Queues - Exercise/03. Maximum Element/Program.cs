using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Stack<int> stack = new Stack<int>();
        Stack<int> maxNums = new Stack<int>();

        maxNums.Push(int.MinValue);

        for (int a = 0; a < n; a++)
        {
            string input = Console.ReadLine();
            if (input.Length > 1)
            {
                int numToPush = Convert.ToInt32(input.Split()[1]);
                stack.Push(numToPush);
                
                if (maxNums.Peek() <= numToPush)
                {
                    maxNums.Push(numToPush);
                }
            }
            else if (input == "2")
            {
                int popedNum = stack.Pop();
                if (maxNums.Peek() == popedNum)
                {
                    maxNums.Pop();
                }
            }
            else
            {
                Console.WriteLine(maxNums.Peek());
            }
        }
    }
}
