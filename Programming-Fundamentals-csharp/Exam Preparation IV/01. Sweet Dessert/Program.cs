using System;

class Program
{
    static void Main()
    {
        decimal money = decimal.Parse(Console.ReadLine());
        long questsCount = long.Parse(Console.ReadLine());
        decimal bananasPrice = decimal.Parse(Console.ReadLine());
        decimal eggsPrice = decimal.Parse(Console.ReadLine());
        decimal berriesPrice = decimal.Parse(Console.ReadLine());
        long totalPortionsCount = (long)Math.Ceiling(questsCount / 6.0);
        decimal totalPrice = (bananasPrice * 2 + eggsPrice * 4 + berriesPrice * 0.2m) * totalPortionsCount;
        if (totalPrice > money)
        {
            Console.Write($"Ivancho will have to withdraw money - he will need {totalPrice - money:f2}lv more.");
        }
        else
        {
            Console.Write($"Ivancho has enough money - it would cost {totalPrice:f2}lv.");
        }
    }
}