using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int basenum = int.Parse(input[0]);
        BigInteger sum = 0;
        string num = input[1];
        for (int a = num.Length - 1; a >= 0; a--)
        {
            int index = num.Length - 1 - a;
            int currentnum = int.Parse(num[index].ToString());
            sum += currentnum * Power(basenum, a);
        }
        Console.WriteLine(sum);
    }

    static BigInteger Power(int a, int b)
    {
        if (b == 0)
        {
            return 1;
        }
        BigInteger sum = a;
        for (int q = 1; q < b; q++)
        {
            sum *= a;
        }
        return sum;
    }
}