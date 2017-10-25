using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        input = Regex.Replace(input, @"\d{2,}", "1");
        char[] arr = input.ToCharArray();
        for (int a = arr.Length - 1; a > 0; a--)
        {
            if (char.IsDigit(arr[a - 1]) && char.IsLetter(arr[a]))
            {
                arr[a - 1] = arr[a];
            }
        }
        Console.Write(string.Join("", arr));
    }
}