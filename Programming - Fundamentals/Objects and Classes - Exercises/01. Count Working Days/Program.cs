using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
        DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
        DateTime[] holidays = new DateTime[]
        {
            new DateTime(1, 1, 1),
            new DateTime(1, 3, 3),
            new DateTime(1, 5, 1),
            new DateTime(1, 5, 6),
            new DateTime(1, 5, 24),
            new DateTime(1, 9, 6),
            new DateTime(1, 9, 22),
            new DateTime(1, 11, 1),
            new DateTime(1, 12, 24),
            new DateTime(1, 12, 25),
            new DateTime(1, 12, 26),
        };
        int wordkingDays = CountWorkingDays(startDate, endDate, holidays);
        Console.Write(wordkingDays);
    }

    static int CountWorkingDays(DateTime startDate, DateTime endDate, DateTime[] holidays)
    {
        int wordkingDays = 0;
        for (DateTime start = startDate; start <= endDate; start = start.AddDays(1))
        {
            bool isWorkingDay = true;
            if (start.DayOfWeek.ToString() == "Saturday" || start.DayOfWeek.ToString() == "Sunday")
            {
                isWorkingDay = false;
            }
            else
            {
                for (int a = 0; a < holidays.Length; a++)
                {
                    if (start.Day == holidays[a].Day && start.Month == holidays[a].Month)
                    {
                        isWorkingDay = false;
                        break;
                    }
                }
            }
            if (isWorkingDay)
            {
                wordkingDays++;
            }
        }
        return wordkingDays;
    }
}