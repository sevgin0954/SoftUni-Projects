using System;

class Program
{
    public static long[] fibCalculated;

    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        fibCalculated = new long[n];

        Console.WriteLine(GetFibonacci(n));
    }

    static long GetFibonacci(long n)
    {
        if (n <= 1)
        {
            return n;
        }

        if (fibCalculated[n - 1] != 0)
        {
            return fibCalculated[n - 1];
        }

        fibCalculated[n - 1] =  GetFibonacci(n - 1) + GetFibonacci(n - 2);
        return fibCalculated[n - 1];
    }
}