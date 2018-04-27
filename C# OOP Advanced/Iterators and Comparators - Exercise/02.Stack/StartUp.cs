using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        CustomStack<int> customStack = new CustomStack<int>();

        while (true)
        {
            string[] input = Console.ReadLine().Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (input[0] == "END")
            {
                break;
            }

            if (input[0] == "Pop")
            {
                try
                {
                    customStack.Pop();
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            else if (input[0] == "Push")
            {
                int[] elementsToPush = input.Skip(1).Select(int.Parse).ToArray();

                foreach (int element in elementsToPush)
                {
                    customStack.Push(element);
                }
            }
        }

        Print(customStack);
        Print(customStack);
    }

    private static void Print(CustomStack<int> customStack)
    {
        foreach (int element in customStack)
        {
            Console.WriteLine(element);
        }
    }
}
