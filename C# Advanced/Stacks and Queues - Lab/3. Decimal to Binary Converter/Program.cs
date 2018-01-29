using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int decNum = int.Parse(Console.ReadLine());
        Stack<int> stack = new Stack<int>();

        if (decNum == 0)
        {
            Console.WriteLine(0);
            return;
        }

        while (decNum > 0)
        {
            int rest = decNum % 2;
            decNum /= 2;

            stack.Push(rest);
        }

        Console.WriteLine(string.Join("", stack.ToArray()));
    }
}