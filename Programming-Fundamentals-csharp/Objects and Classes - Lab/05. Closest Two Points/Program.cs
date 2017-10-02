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
        int n = int.Parse(Console.ReadLine());
        Point[] points = new Point[n];
        ReadPoints(points, n);
        Point[] closestPoints = new Point[2];
        double minDistance = double.MaxValue;
        for (int a = 0; a < points.Length - 1; a++)
        {
            for (int b = a + 1; b < points.Length; b++)
            {
                double currentDistance = CalcDistance(points[a], points[b]);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    closestPoints[0] = points[a];
                    closestPoints[1] = points[b];
                }
            }
        }
        Console.WriteLine(minDistance);
        Console.WriteLine($"({closestPoints[0].X}, {closestPoints[0].Y})");
        Console.Write($"({closestPoints[1].X}, {closestPoints[1].Y})");
    }

    static void ReadPoints(Point[] points ,int count)
    {
        for (int a = 0; a < points.Length; a++)
        {
            int[] xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            points[a] = new Point
            {
                X = xy[0],
                Y = xy[1]
            };
        }
    }

    static double CalcDistance(Point point1, Point point2)
    {
        double pointsDistance = Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2));
        return pointsDistance;
    }
}