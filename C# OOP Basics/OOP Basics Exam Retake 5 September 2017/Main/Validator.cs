using System;

public static class Validator
{
    public static void  CheckIsNegative(double value, string type, string propertyName)
    {
        if (value < 0)
        {
            throw new ArgumentException($"{type} is not registered, because of it's {propertyName}");
        }
    }

    public static void CheckIsValueOverThan(double value, double maxValue, string type, string propertyName)
    {
        if (value > maxValue)
        {
            throw new ArgumentException($"{type} is not registered, because of it's {propertyName}");
        }
    }

    public static void CheckIsValueLessThan(double value, double maxValue, string type, string propertyName)
    {
        if (value >= maxValue)
        {
            throw new ArgumentException($"{type} is not registered, because of it's {propertyName}");
        }
    }
}
