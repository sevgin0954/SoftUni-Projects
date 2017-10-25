using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(input, @"(?<= |\/|\\|\(|\)|^)[a-zA-Z]\w{2,24}(?=$|\/|\\|\(|\)| )");
        string[] bestLenUsernames = new string[2];
        List<string> validUsernames = new List<string>();
        foreach (Match validUsername in matches)
        {
            validUsernames.Add(validUsername.Value);
        }
        int bestUsernameLen = -1;
        for (int a = 0; a < validUsernames.Count - 1; a++)
        {
            int usernameLen = validUsernames[a].Length + validUsernames[a + 1].Length;
            if (usernameLen > bestUsernameLen)
            {
                bestUsernameLen = usernameLen;
                bestLenUsernames[0] = validUsernames[a];
                bestLenUsernames[1] = validUsernames[a + 1];
            }
        }
        Console.WriteLine(bestLenUsernames[0]);
        Console.Write(bestLenUsernames[1]);
    }
}