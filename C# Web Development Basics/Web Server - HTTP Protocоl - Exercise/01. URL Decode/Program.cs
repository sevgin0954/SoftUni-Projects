using System;
using System.Net;

class Program
{
    static void Main()
    {
        string inputUrl = Console.ReadLine();
        string decodedUrl = WebUtility.UrlDecode(inputUrl);
        Console.WriteLine(decodedUrl);
    }
}