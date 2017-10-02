using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger fakt = n;
        for (int a = 2; a < n; a++)
        {
            fakt *= a;
        }
        Console.Write(fakt);
    }
}