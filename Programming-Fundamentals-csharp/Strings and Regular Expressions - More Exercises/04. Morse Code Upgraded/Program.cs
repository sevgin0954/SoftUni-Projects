using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] nums = input.Split('|');
        string output = "";
        for (int a = 0; a < nums.Length; a++)
        {
            output += Decoder(nums[a]).ToString();
        }
        Console.Write(output);
    }

    static char Decoder(string code)
    {
        int totalSum = 0;
        MatchCollection zerosSequence = Regex.Matches(code, @"0{2,}");
        MatchCollection onesSequence = Regex.Matches(code, @"1{2,}");
        totalSum += CountElements(zerosSequence);
        totalSum += CountElements(onesSequence);
        for (int a = 0; a < code.Length; a++)
        {
            if (code[a] == '0')
            {
                totalSum += 3;
            }
            else if (code[a] == '1')
            {
                totalSum += 5;
            }
        }
        return (char)totalSum;
    }

    static int CountElements(MatchCollection elements)
    {
        int count = 0;
        foreach (Match match in elements)
        {
            count += match.Value.Length;
        }
        return count;
    }
}