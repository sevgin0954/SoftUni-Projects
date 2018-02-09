using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Func<int, int[], bool> isDivisible = (num, divs) => divs.All(d => num % d == 0);

        for (int a = 1; a <= n; a++)
        {
            if (isDivisible(a, dividers))
            {
                Console.Write(a + " ");
            }
        }
    }
}