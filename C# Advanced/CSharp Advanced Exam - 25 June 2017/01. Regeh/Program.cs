using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Regex regex = new Regex(@"\[[a-zA-Z]+<(?<num1>\d+)REGEH(?<num2>\d+)>[a-zA-Z]+\]");
        MatchCollection matches = regex.Matches(input);

        int index = 0;

        foreach (Match math in matches)
        {
            index += int.Parse(math.Groups["num1"].Value);

            if (index >= input.Length)
            {
                index -= input.Length - 1;
            }

            Console.Write(input[index]);
            index += int.Parse(math.Groups["num2"].Value);

            if (index >= input.Length)
            {
                index -= input.Length - 1;
            }

            Console.Write(input[index]);
        }
    }
}