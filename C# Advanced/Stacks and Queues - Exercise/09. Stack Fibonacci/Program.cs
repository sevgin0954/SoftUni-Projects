using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Stack<long> stack = new Stack<long>(new long[] { 0, 1 });
        
        for (int a = 2; a <= n; a++)
        {
            long firstNum = stack.Peek();
            long secondNum = stack.Pop() + stack.Pop();

            stack.Push(firstNum);
            stack.Push(secondNum);
        }

        Console.WriteLine(stack.Pop());
    }
}