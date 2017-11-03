using System;

class StartUp
{
    static void Main()
    {
        string[] firstDate = Console.ReadLine().Split();
        int year1 = int.Parse(firstDate[0]);
        int month1 = int.Parse(firstDate[1]);
        int day1 = int.Parse(firstDate[2]);
        DateTime date1 = new DateTime(year1, month1, day1);

        string[] secondDate = Console.ReadLine().Split();
        int year2 = int.Parse(secondDate[0]);
        int month2 = int.Parse(secondDate[1]);
        int day2 = int.Parse(secondDate[2]);
        DateTime date2 = new DateTime(year2, month2, day2);

        Console.WriteLine(Math.Abs((date1 - date2).Days));
    }
}
