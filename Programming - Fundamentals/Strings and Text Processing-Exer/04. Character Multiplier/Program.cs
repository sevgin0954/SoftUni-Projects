using System;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        Console.WriteLine(SumCharCodes(input[0], input[1]));
    }

    static int SumCharCodes(string a, string b)
    {
        int sum = 0;
        if (a.Length < b.Length)
        {
            string temp = a;
            a = b;
            b = temp;
        }
        for (int q = 0; q < a.Length; q++)
        {
            if (q >= b.Length)
            {
                sum += a[q];
            }
            else
            {
                sum += a[q] * b[q];
            }
        }
        return sum;
    }
}