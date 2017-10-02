using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<char, char> dict = new Dictionary<char, char>();
        bool isExchangeble = true;
        string[] input = Console.ReadLine().Split();
        string word1 = "";
        string word2 = "";
        if (input[0].Length > input[1].Length)
        {
            word1 = input[1];
            word2 = input[0];
        }
        else
        {
            word1 = input[0];
            word2 = input[1];
        }
        for (int a = 0; a < word2.Length; a++)
        {
            if (a < word1.Length)
            {
                if (dict.ContainsKey(word1[a]))
                {
                    if (dict[word1[a]] != word2[a])
                    {
                        isExchangeble = false;
                        break;
                    }
                }
                else
                {
                    if (dict.ContainsValue(word2[a]))
                    {
                        isExchangeble = false;
                        break;
                    }
                    dict[word1[a]] = word2[a];
                }
            }
            else
            {
                if (!dict.ContainsValue(word2[a]))
                {
                    isExchangeble = false;
                    break;
                }
            }
        }
        Console.Write(isExchangeble.ToString().ToLower());
    }
}