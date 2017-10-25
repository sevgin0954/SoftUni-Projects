using System;
using System.IO;

class Program
{
    static void Main()
    {
        string text = File.ReadAllText("sample_text.txt");
        char[] separators = ",.:?!".ToCharArray();
        string aa = "";
        bool isFirst = true;
        for (int a = 0; a < text.Length; a++)
        {
            for (int b = 0; b < separators.Length; b++)
            {
                if (text[a] == separators[b])
                {
                    if (!isFirst)
                    {
                        aa += ", ";
                    }
                    isFirst = false;
                    aa += text[a];
                    break;
                }
            }
        }
        File.WriteAllText("output.txt", aa);
    }
}