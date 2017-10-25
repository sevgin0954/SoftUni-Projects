using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string hex = "";
        for (int a = 0; a < input.Length; a++)
        {
            int dec = input[a];
            hex += "\\u" + DecToHex(dec);
        }
        Console.WriteLine(hex);
    }

    static string DecToHex(int dec)
    {
        string hex = "";
        while (dec > 0)
        {
            int rest = dec % 16;
            dec /= 16;
            switch (rest)
            {
                case 10:
                    hex += 'a';
                    break;
                case 11:
                    hex += 'b';
                    break;
                case 12:
                    hex += 'c';
                    break;
                case 13:
                    hex += 'd';
                    break;
                case 14:
                    hex += 'e';
                    break;
                case 15:
                    hex += 'f';
                    break;
                default:
                    hex += rest;
                    break;
            }
        }
        char[] arr = hex.ToCharArray();
        Array.Reverse(arr);
        hex = new string(arr);
        string addZeroes = new string('0', 4 - hex.Length);
        hex = addZeroes + hex;
        return hex;
    }
}