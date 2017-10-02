using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        decimal totalPrice = 0;
        for (int a = 0; a < n; a++)
        {
            decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
            DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
            int capsuleCount = int.Parse(Console.ReadLine());
            int daysInMoth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
            decimal currentPrice = (decimal)daysInMoth * capsuleCount * pricePerCapsule;
            Console.WriteLine($"The price for the coffee is: ${currentPrice:f2}");
            totalPrice += currentPrice;
        }
        Console.Write($"Total: ${totalPrice:f2}");
    }
}