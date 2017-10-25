using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Over!")
            {
                break;
            }
            int len = int.Parse(Console.ReadLine());
            string pattern = string.Format(@"^\d+(?<massage>[a-zA-Z]{{{0}}})[^a-zA-Z]*$", len);
            Regex regx = new Regex(pattern);
            if (regx.IsMatch(input))
            {
                Match massage = regx.Match(input);
                Console.WriteLine(massage.Groups["massage"] + " == " + DecrypteMassage(massage.Value, pattern));
            }
        }
    }

    static string DecrypteMassage(string massage, string pattern)
    {
        string decryptedMassage = "";
        MatchCollection matches = Regex.Matches(massage, @"\d+");
        string textOnly = Regex.Match(massage, pattern).Groups["massage"].Value;
        foreach (Match match in matches)
        {
            string digits = match.Value;
            for (int a = 0; a < digits.Length; a++)
            {
                int index = int.Parse(digits[a].ToString());
                if (index >= 0 && index < textOnly.Length)
                {
                    decryptedMassage += textOnly[index];
                }
                else
                {
                    decryptedMassage += " ";
                }
            }
        }
        return decryptedMassage;
    }
}