using System;
using System.Linq;

class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}
class Program
{
    static void Main()
    {
        int[] x1y1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] x2y2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Point p1 = new Point()
        {
            X = x1y1[0],
            Y = x1y1[1]
        };
        Point p2 = new Point()
        {
            X = x2y2[0],
            Y = x2y2[1]
        };
        Console.Write(CalcDistance(p1, p2));
}
    static double CalcDistance(Point point1, Point point2)
    {
        double pointsDistance = Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2));
        return pointsDistance;
    }
}