using System;

class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumation, double tankCapacity)
        : base(fuelQuantity, fuelConsumation, tankCapacity) { }

    internal override void Drive(double distance)
    {
        DriveCalculate(distance, 1.4);
    }

    internal void DriveEmpty(double distance)
    {
        DriveCalculate(distance, 0);
    }

    private void DriveCalculate(double distance, double additionalConsumation)
    {
        double fuelNeeded = distance * (FuelConsumation + additionalConsumation);

        if (fuelNeeded > FuelQuantity)
        {
            throw new ArgumentException($"{this.GetType()} needs refueling");
        }

        FuelQuantity -= fuelNeeded;
        Console.WriteLine($"{this.GetType()} travelled {distance} km");
    }
}
