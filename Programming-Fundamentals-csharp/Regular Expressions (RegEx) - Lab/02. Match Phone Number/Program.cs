using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Regex regx = new Regex(@"\+359( |-)2\1\d{3}\1\d{4}\b");
        MatchCollection matches = regx.Matches(input);
        bool isFirst = true;
        foreach (Match match in matches)
        {
            if (isFirst == false)
            {
                Console.Write(", ");
            }
            isFirst = false;
            Console.Write(match);
        }
    }
}