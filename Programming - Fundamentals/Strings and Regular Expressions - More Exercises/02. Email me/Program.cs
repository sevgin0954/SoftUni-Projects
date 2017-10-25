using System;

class Program
{
    static void Main()
    {
        string email = Console.ReadLine();
        int index = email.IndexOf('@');
        string before = email.Substring(0, index);
        string after = email.Substring(index + 1);
        int beforeSum = SumChars(before);
        int afterSum = SumChars(after);
        if (beforeSum - afterSum >= 0)
        {
            Console.Write("Call her!");
        }
        else
        {
            Console.Write("She is not the one.");
        }
    }

    static int SumChars(string input)
    {
        int sum = 0;
        for (int a = 0; a < input.Length; a++)
        {
            sum += input[a];
        }
        return sum;
    }
}