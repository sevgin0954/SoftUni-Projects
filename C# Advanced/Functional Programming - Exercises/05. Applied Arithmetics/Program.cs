using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Func<int[], int[]> add1 = (ns) => ns.Select(n => n + 1).ToArray();
        Func<int[], int[]> multiplyBy2 = (ns) => ns.Select(n => n * 2).ToArray();
        Func<int[], int[]> subtract1 = (ns) => ns.Select(n => n - 1).ToArray();
        Action<int[]> print = (ns) => Console.Write(string.Join(" ", ns));

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "end")
            {
                break;
            }

            switch (command)
            {
                case "add":
                    nums = add1(nums);
                    break;
                case "multiply":
                    nums = multiplyBy2(nums);
                    break;
                case "subtract":
                    nums = subtract1(nums);
                    break;
                case "print":
                    print(nums);
                    Console.WriteLine();
                    break;
            }
        }
    }
}