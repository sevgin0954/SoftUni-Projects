using System;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        decimal nHalf = n / 2m;
        int count = 0;
        while (n >= m)
        {
            n -= m;
            count++;
            if (n == nHalf)
            {
                if (y != 0)
                {
                    n /= y;
                }
            }
        }
        Console.WriteLine(n);
        Console.Write(count);

    }
}
