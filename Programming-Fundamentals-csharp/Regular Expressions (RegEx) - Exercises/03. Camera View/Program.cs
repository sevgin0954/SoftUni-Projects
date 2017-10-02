using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] nums = Console.ReadLine().Split();
        int skipCount = int.Parse(nums[0]);
        int takeCount = int.Parse(nums[1]);
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(input, @"(?<=\|<).+?(?=(\||$))");
        bool isFist = true;
        foreach (Match match in matches)
        {
            string result = "";
            if (!isFist)
            {
                Console.Write(", ");
            }
            isFist = false;
            if (skipCount + takeCount >= match.Value.Length)
            {
                result = match.Value.Substring(skipCount);
            }
            else
            {
                result = match.Value.Substring(skipCount, takeCount);
            }
            Console.Write(result);
        }
    }
}