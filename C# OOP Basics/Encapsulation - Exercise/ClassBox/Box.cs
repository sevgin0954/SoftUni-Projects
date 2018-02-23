public class Box
{
    double length;
    double width;
    double height;

    public Box(double lenght, double width, double height)
    {
        Length = lenght;
        Width = width;
        Height = height;
    }

    public double Length
    {
        get { return length; }

        set
        {
            if (value <= 0)
            {
                throw new System.ArgumentException("Length cannot be zero or negative.");
            }

            length = value;
        }
    }

    public double Width
    {
        get { return width; }

        set
        {
            if (value <= 0)
            {
                throw new System.ArgumentException("Width cannot be zero or negative.");
            }

            width = value;
        }
    }

    public double Height
    {
        get { return height; }

        set
        {
            if (value <= 0)
            {
                throw new System.ArgumentException("Height cannot be zero or negative.");
            }

            height = value;
        }
    }

    public double CalculateSurfaceArea()
    {
        return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
    }

    public double CalculateLateralSurfaceArea()
    {
        return 2 * Length * Height + 2 * Width * Height;
    }

    public double CalculateVolume()
    {
        return Length * Width * Height;
    }
}