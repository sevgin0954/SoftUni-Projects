using System;

class Program
{
    static void Main()
    {
        string num1 = Console.ReadLine().TrimStart('0');
        string num2 = Console.ReadLine().TrimStart('0');
        Console.WriteLine(SumBigNums(num1, num2));
    }

    static string SumBigNums(string num1, string num2)
    {
        string result = "";
        if (num1.Length > num2.Length)
        {
            string temp = num1;
            num1 = num2;
            num2 = temp;
        }
        int rest = 0;
        char[] arr1 = num1.ToCharArray();
        Array.Reverse(arr1);
        char[] arr2 = num2.ToCharArray();
        Array.Reverse(arr2);
        num1 = new string(arr1);
        num2 = new string(arr2);
        for (int a = 0; a < num1.Length; a++)
        {
            int n1 = int.Parse(num1[a].ToString());
            int n2 = int.Parse(num2[a].ToString());
            int num = n1 + n2 + rest;
            if (num > 9)
            {
                rest = num / 10; 
                num %= 10;
            }
            else
            {
                rest = 0;
            }
            result += num;
        }
        for (int a = num1.Length; a < num2.Length; a++)
        {
            int n1 = int.Parse(num2[a].ToString());
            int num = n1 + rest;
            if (num > 9)
            {
                rest = num / 10;
                num %= 10;
            }
            else
            {
                rest = 0;
            }
            result += num;
        }
        if (rest > 0)
        {
            result += rest;
        }
        char[] arr = result.ToCharArray();
        Array.Reverse(arr);
        result = new string(arr);
        return result;
    }
}