using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(input, @"(?<=<p>).*?(?=<\/p>)");
        foreach (Match match in matches)
        {
            string decryptedSentece = "";
            string sentece = match.Value;
            sentece = Regex.Replace(sentece, @"[^a-z0-9]+", " ");
            sentece = Regex.Replace(sentece, @" +", " ");
            for (int a = 0; a < sentece.Length; a++)
            {
                if (sentece[a] >= 'a' && sentece[a] <= 'm')
                {
                    decryptedSentece += (char)(sentece[a] + 13);
                }
                else if (sentece[a] >= 'n' && sentece[a] <= 'z')
                {
                    decryptedSentece += (char)(sentece[a] - 13);
                }
                else
                {
                    decryptedSentece += sentece[a];
                }
            }
            Console.Write(decryptedSentece);
        }
    }
}