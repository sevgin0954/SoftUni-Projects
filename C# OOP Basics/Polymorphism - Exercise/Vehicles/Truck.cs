public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumation, double tankCapacity)
        : base(fuelQuantity, fuelConsumation + 1.6, tankCapacity) { }

    internal override void Refuel(double fuelAmount)
    {
        Validator.ValidateFuel(fuelAmount, TankCapacity);
        fuelAmount *= 0.95;
        FuelQuantity += fuelAmount;
    }
}
