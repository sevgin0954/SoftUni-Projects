using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<char> nonNums = new List<char>();
        List<int> nums = new List<int>();
        List<int> take = new List<int>();
        List<int> skip = new List<int>();
        int count = 0;
        for (int a = 0; a < input.Length; a++)
        {
            if (input[a] < 48 || input[a] > 57)
            {
                nonNums.Add(input[a]);
            }
            else
            {
                int num = input[a] - '0';
                nums.Add(input[a] - '0');
                if (count % 2 == 0)
                {
                    take.Add(num);
                }
                else
                {
                    skip.Add(num);
                }
                count++;
            }
        }
        int totalSkip = 0;
        string decryptedMassage = "";
        for (int a = 0; a < take.Count; a++)
        {
            int takeCount = take[a];
            int skipCount = skip[a];
            decryptedMassage += new string(nonNums.Skip(totalSkip).Take(takeCount).ToArray());
            totalSkip += takeCount + skipCount;
        }
        Console.WriteLine(decryptedMassage);
    }
}