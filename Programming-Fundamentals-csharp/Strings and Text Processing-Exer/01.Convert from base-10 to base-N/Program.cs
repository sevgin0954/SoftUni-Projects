using System;
using System.Linq;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger[] input = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
        string convertedNum = "";
        while (input[1] > 0)
        {
            convertedNum += input[1] % input[0];
            input[1] /= input[0];
        }
        char[] arr = convertedNum.ToCharArray();
        Array.Reverse(arr);
        Console.WriteLine(arr);
    }
}