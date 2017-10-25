using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        SortedDictionary<double, int> dict = new SortedDictionary<double, int>();
        double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
        foreach (double n in nums)
        {
            if (dict.ContainsKey(n))
            {
                dict[n]++;
            }
            else
            {
                dict[n] = 1;
            }
        }
        
        foreach (KeyValuePair<double, int> dc in dict)
        {
            Console.WriteLine($"{dc.Key} -> {dc.Value}");
        }
    }
}