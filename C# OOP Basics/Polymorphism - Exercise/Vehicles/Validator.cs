using System;

static class Validator
{
    internal static void ValidateFuel(double fuelQuantity, double tankCapacity)
    {
        if (fuelQuantity <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (fuelQuantity > tankCapacity)
        {
            throw new ArgumentException($"Cannot fit {fuelQuantity} fuel in the tank");
        }
    }
}
