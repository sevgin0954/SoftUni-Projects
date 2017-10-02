using System;
using System.Linq;

class Rectangle
{
    public int Top { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Left { get; set; }
    public int Bottom
    {
        get
        {
            return Top + Height;
        }
    }
    public int Right
    {
        get
        {
            return Left + Width;
        }
    }
}

class Program
{
    static void Main()
    {
        int[] rectangle1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] rectangle2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Rectangle r1 = new Rectangle()
        {
            Left = rectangle1[0],
            Top = rectangle1[1],
            Width = rectangle1[2],
            Height = rectangle1[3]
        };
        Rectangle r2 = new Rectangle()
        {
            Left = rectangle2[0],
            Top = rectangle2[1],
            Width = rectangle2[2],
            Height = rectangle2[3]
        };
        bool isInside = CheckIsInside(r1, r2);
        Console.Write(isInside ? "Inside" : "Not inside");
    }

    static bool CheckIsInside(Rectangle r1, Rectangle r2)
    {
        if (r1.Left < r2.Left)
        {
            return false;
        }
        if (r1.Top < r2.Top)
        {
            return false;
        }
        if (r1.Right > r2.Right)
        {
            return false;
        }
        if (r1.Bottom > r2.Bottom)
        {
            return false;
        }
        return true;
    }
}