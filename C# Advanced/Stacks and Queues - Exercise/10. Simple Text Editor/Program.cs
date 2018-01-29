using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int commandCount = int.Parse(Console.ReadLine());
        StringBuilder text = new StringBuilder();
        Stack<string> history = new Stack<string>();

        history.Push(text.ToString());

        for (int a = 0; a < commandCount; a++)
        {
            string[] command = Console.ReadLine().Split();
            if (command[0] == "1")
            {
                history.Push(text.ToString());

                text.Append(command[1]);
            }
            else if (command[0] == "2")
            {
                history.Push(text.ToString());

                int startIndex = text.Length - int.Parse(command[1]);
                text.Remove(startIndex, text.Length - startIndex);
            }
            else if (command[0] == "3")
            {
                int index = int.Parse(command[1]) - 1;
                Console.WriteLine(text[index]);
            }
            else
            {
                text.Clear();
                text.Append(history.Pop());
            }
        }
    }
}