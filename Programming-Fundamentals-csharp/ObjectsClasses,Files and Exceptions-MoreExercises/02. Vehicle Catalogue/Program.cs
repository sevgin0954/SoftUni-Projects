using System;
using System.Collections.Generic;
using System.Linq;

class Vehicle
{
    public string Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int HorsePower { get; set; }
}

class Program
{
    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>();
        vehicles = ReadVehicles();
        PrintVihicleData(vehicles);
        int carsHoursepow = vehicles.Where(v => v.Type == "Car").Sum(v => v.HorsePower);
        int carsCount = vehicles.Where(v => v.Type == "Car").Count();
        double avgHoursePowCars = (double)carsHoursepow / carsCount;
        int trucksHoursepow = vehicles.Where(v => v.Type == "Truck").Sum(v => v.HorsePower);
        int trucksCount = vehicles.Where(v => v.Type == "Truck").Count();
        double avgHoursePowTrucks = (double)trucksHoursepow / trucksCount;
        if (trucksCount == 0)
        {
            avgHoursePowTrucks = 0;
        }
        if (carsCount == 0)
        {
            avgHoursePowCars = 0;
        }
        Console.WriteLine($"Cars have average horsepower of: {avgHoursePowCars:f2}.");
        Console.Write($"Trucks have average horsepower of: {avgHoursePowTrucks:f2}.");
    }

    static List<Vehicle> ReadVehicles()
    {
        List<Vehicle> vehicles = new List<Vehicle>();
        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "End")
            {
                break;
            }
            string type = "";
            if (input[0].ToLower() == "car")
            {
                type = "Car";
            }
            else
            {
                type = "Truck";
            }
            string model = input[1];
            string color = input[2];
            int hoursePower = int.Parse(input[3]);
            Vehicle vehicle = new Vehicle
            {
                Type = type,
                Model = model,
                Color = color,
                HorsePower = hoursePower
            };
            vehicles.Add(vehicle);
        }
        return vehicles;
    }

    static void PrintVihicleData(List<Vehicle> vehicles)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Close the Catalogue")
            {
                break;
            }
            Vehicle vehicle = vehicles.First(a => a.Model == input);
            Console.WriteLine($"Type: {vehicle.Type}");
            Console.WriteLine($"Model: {vehicle.Model}");
            Console.WriteLine($"Color: {vehicle.Color}");
            Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
        }
    }
}