using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        List<string> html = new List<string>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                break;
            }
            string output = input;
            Regex regx = new Regex(@"<a(.+)>(.+)</a>");
            output = regx.Replace(input, "[URL$1]$2[/URL]");
            html.Add(output);
        }
        Console.Write(string.Join("\r\n", html));
    }
}