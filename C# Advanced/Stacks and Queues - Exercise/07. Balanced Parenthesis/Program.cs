using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        if (input.Length % 2 != 0)
        {
            Console.WriteLine("NO");
            return;
        }

        Stack<char> openingParenthesis = new Stack<char>();

        for (int a = 0; a < input.Length; a++)
        {
            char parenthesis = ' ';

            if (")}]".Contains(input[a]))
            {
                switch (input[a])
                {
                    case ')':
                        parenthesis = '(';
                        break;
                    case '}':
                        parenthesis = '{';
                        break;
                    case ']':
                        parenthesis = '[';
                        break;
                }

                if (openingParenthesis.Peek() == parenthesis)
                {
                    openingParenthesis.Pop();
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            else
            {
                openingParenthesis.Push(input[a]);
            }
        }

        Console.WriteLine("YES");
    }
}