public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumation, double tankCapacity)
        : base(fuelQuantity, fuelConsumation + 0.9, tankCapacity) { }
}
