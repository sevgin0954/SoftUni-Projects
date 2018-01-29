using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Stack<int> openingBracketIndexes = new Stack<int>();

        for (int a = 0; a <input.Length; a++)
        {
            int openingBracketIndex = 0;
            int closingBracketIndex = 0;

            if (input[a] == '(')
            {
                openingBracketIndexes.Push(a);
            }
            else if (input[a] == ')')
            {
                openingBracketIndex = openingBracketIndexes.Pop();
                closingBracketIndex = a;

                // Print result
                Console.WriteLine(input.Substring(openingBracketIndex, closingBracketIndex - openingBracketIndex + 1));
            }
        }
    }
}