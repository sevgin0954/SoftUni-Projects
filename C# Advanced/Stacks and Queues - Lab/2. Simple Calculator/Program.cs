using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine()
            .Split()
            .Reverse()
            .ToArray();

        Stack<string> stack = new Stack<string>(input);

        while (stack.Count() > 1)
        {
            int firstNum = int.Parse(stack.Pop());
            string sign = stack.Pop();
            int secondNum = int.Parse(stack.Pop());

            int result = 0;
            if (sign == "+")
            {
                result = firstNum + secondNum;
            }
            else
            {
                result = firstNum - secondNum;
            }

            stack.Push(result.ToString());
        }

        Console.Write(stack.Pop());
    }
}