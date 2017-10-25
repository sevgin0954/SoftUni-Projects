using System;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Regex regx = new Regex(@"<.+?>");
        while (regx.IsMatch(input))
        {
            Match bomb = regx.Match(input);
            int len = CalculateBombStrength(bomb.Value);
            int startIndex = input.IndexOf('<') - len;
            int endIndex = input.IndexOf('>') + len;
            if (startIndex < 0)
            {
                startIndex = 0;
            }
            if (endIndex > input.Length - 1)
            {
                endIndex = input.Length - 1;
            }
            input = Replace(input, startIndex, endIndex);
        }
        Console.Write(input);
    }

    static int CalculateBombStrength(string bomb)
    {
        char a = bomb[1];
        char b = bomb[2];
        return Math.Abs(a - b);
    }

    static string Replace(string input, int startIndex, int endIndex)
    {
        StringBuilder temp = new StringBuilder();
        for (int a = 0; a < input.Length; a++)
        {
            if (a < startIndex || a > endIndex)
            {
                temp.Append(input[a]);
            }
            else
            {
                temp.Append('_');
            }
        }
        return temp.ToString();
    }
}