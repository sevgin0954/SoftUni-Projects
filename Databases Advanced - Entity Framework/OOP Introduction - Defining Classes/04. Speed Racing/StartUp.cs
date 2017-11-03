using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        Dictionary<string, Car> namesCars = new Dictionary<string, Car>();
        int n = int.Parse(Console.ReadLine());

        for (int a = 0; a < n; a++)
        {
            string[] input = Console.ReadLine().Split(' ');
            string modelName = input[0];
            double fuelAmount = double.Parse(input[1]);
            double fuelConsumationPerKm = double.Parse(input[2]);
            Car car = new Car
            {
                CarModel = modelName,
                FuelAmount = fuelAmount,
                FuelConsumationPerKm = fuelConsumationPerKm
            };
            namesCars.Add(modelName, car);
        }

        while (true)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input[0] == "End")
            {
                break;
            }
            string modelName = input[1];
            double kmAmount = double.Parse(input[2]);
            double fuelConsumation = namesCars[modelName].FuelConsumation(kmAmount);
            if (fuelConsumation <= namesCars[modelName].FuelAmount)
            {
                namesCars[modelName].TravelDistance += kmAmount;
                namesCars[modelName].FuelAmount -= fuelConsumation;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        PrintCarsInfo(namesCars);
    }

    static void PrintCarsInfo(Dictionary<string, Car> namesCars)
    {
        foreach (KeyValuePair<string, Car> nameCar in namesCars)
        {
            Console.WriteLine($"{nameCar.Value.CarModel} {nameCar.Value.FuelAmount:f2} {nameCar.Value.TravelDistance}");
        }
    }
}