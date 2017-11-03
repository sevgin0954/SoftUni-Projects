class Car
{
    public string CarModel { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumationPerKm { get; set; }
    public double TravelDistance { get; set; } = 0;

    public double FuelConsumation(double kmAmount)
    {
        double totalFuelNeeded = kmAmount * FuelConsumationPerKm;
        return totalFuelNeeded;
    }
}