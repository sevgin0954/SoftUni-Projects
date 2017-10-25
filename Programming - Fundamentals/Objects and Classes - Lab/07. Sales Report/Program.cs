using System;
using System.Collections.Generic;

class Sale
{
    public string Town { get; set; }
    public string Product { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Sale[] sales = ReadSales(n);
        SortedDictionary<string, decimal> TownsSales = TotalSalesByTown(sales);
        PrintDict(TownsSales);
    }

    static Sale[] ReadSales(int count)
    {
        Sale[] sales = new Sale[count];
        for (int a = 0; a < count; a++)
        {
            string[] input = Console.ReadLine().Split();
            sales[a] = new Sale
            {
                Town = input[0],
                Product = input[1],
                Price = decimal.Parse(input[2]),
                Quantity = decimal.Parse(input[3])
            };
        }
        return sales;
    }

    static SortedDictionary<string, decimal> TotalSalesByTown(Sale[] sales)
    {
        SortedDictionary<string, decimal> townsSales = new SortedDictionary<string, decimal>();
        for (int a = 0; a < sales.Length; a++)
        {
            if (!townsSales.ContainsKey(sales[a].Town))
            {
                townsSales[sales[a].Town] = 0;
            }
            townsSales[sales[a].Town] += sales[a].Price * sales[a].Quantity;
        }
        return townsSales;
    }

    static void PrintDict(SortedDictionary<string, decimal> dict)
    {
        foreach (KeyValuePair<string, decimal> a in dict)
        {
            Console.WriteLine($"{a.Key} -> {a.Value:f2}");
        }
    }
}