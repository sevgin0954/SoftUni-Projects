using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, double[]> namesPricesQuantitys = new Dictionary<string, double[]>();
        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "stocked")
            {
                break;
            }
            string name = input[0];
            double price = double.Parse(input[1]);
            int quantity = int.Parse(input[2]);
            if (!namesPricesQuantitys.ContainsKey(name))
            {
                namesPricesQuantitys[name] = new double[2];
            }
            namesPricesQuantitys[name][0] = price;
            namesPricesQuantitys[name][1] += quantity;
        }
        double grandTotal = 0;
        foreach (KeyValuePair<string, double[]> namePriceQuantity in namesPricesQuantitys)
        {
            double sum = namePriceQuantity.Value[0] * namePriceQuantity.Value[1];
            grandTotal += sum;
            Console.WriteLine($"{namePriceQuantity.Key}: ${namePriceQuantity.Value[0]:f2} * {namePriceQuantity.Value[1]} = ${sum:f2}");
        }
        Console.WriteLine(new string('-', 30));
        Console.Write($"Grand Total: ${grandTotal:f2}");
    }
}