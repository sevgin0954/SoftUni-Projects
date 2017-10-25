using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string text = File.ReadAllText("sample_text.txt");
        char[] separators = ",.:?!".ToCharArray();
        text = string.Join("", text.Where(t => !separators.Contains(t)).ToArray());
        File.WriteAllText("output.txt", text);
    }
}