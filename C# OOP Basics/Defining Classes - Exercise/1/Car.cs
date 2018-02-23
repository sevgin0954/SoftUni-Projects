using System;

public class Car
{
    string model;
    float fuelAmount;
    float fuelConsumation;
    float traveledDistance = 0;

    public Car(string model, float fuelAmount, float fuelConsumation)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumation = fuelConsumation;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public float FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public float FuelConsumation
    {
        get { return fuelConsumation; }
        set { fuelConsumation = value; }
    }

    public float TraveledDistance
    {
        get { return traveledDistance; }
        set { traveledDistance = value; }
    }

    public void Drive(float distance)
    {
        float requiredFuel = distance * FuelConsumation;

        if (requiredFuel > FuelAmount)
        {
            throw new ArgumentException("Insufficient fuel for the drive");
        }

        FuelAmount -= requiredFuel;
        TraveledDistance += distance;
    }

    public override string ToString()
    {
        return $"{Model} {FuelAmount:f2} {TraveledDistance}";
    }
}
