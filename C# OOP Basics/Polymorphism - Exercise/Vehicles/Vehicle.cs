using System;

public class Vehicle
{
    double fuelQuantity;
    double fuelConsumation;
    double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumation, double tankCapacity)
    {
        TankCapacity = tankCapacity;
        FuelQuantity = fuelQuantity;
        FuelConsumation = fuelConsumation;
    }

    public double TankCapacity
    {
        get => tankCapacity;
        set
        {
            tankCapacity = value;
        }
    }

    public double FuelQuantity
    {
        get => fuelQuantity;
        set
        {
            fuelQuantity = value;
        }
    }

    public double FuelConsumation
    {
        get => fuelConsumation;
        set
        {
            fuelConsumation = value;
        }
    }

    internal virtual void Drive(double distance)
    {
        double fuelNeeded = distance * FuelConsumation;

        if (fuelNeeded > FuelQuantity)
        {
            throw new ArgumentException($"{this.GetType()} needs refueling");
        }

        FuelQuantity -= fuelNeeded;
        Console.WriteLine($"{this.GetType()} travelled {distance} km");
    }

    internal virtual void Refuel(double fuelAmount)
    {
        Validator.ValidateFuel(fuelAmount, TankCapacity);
        FuelQuantity += fuelAmount;
    }

    public override string ToString()
    {
        return $"{this.GetType()}: {fuelQuantity:f2}";
    }
}
