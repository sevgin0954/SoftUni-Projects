using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            int n = int.Parse(Console.ReadLine());
            if (n >= 0)
            {
                Console.WriteLine(n);
            }
            else
            {
                Console.WriteLine("My first exception is awesome!!!");
                return;
            }
        }
    }
}