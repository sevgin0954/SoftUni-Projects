using System;
using System.Linq;
using System.Reflection;

class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Box box = new Box(length, width, height);
            Console.WriteLine($"Surface Area - {box.CalculateSurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.CalculateLateralSurface():f2}");
            Console.WriteLine($"Volume - {box.CalculateVolume():f2}");
        }
        catch (ArgumentException ag)
        {
            Console.WriteLine(ag.Message);
        }
    }
}