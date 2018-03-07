using System;

class StartUp
{
    static void Main()
    {
        Car car = (Car)ReadVehicle();
        Truck truck = (Truck)ReadVehicle();
        Bus bus = (Bus)ReadVehicle();

        int n = int.Parse(Console.ReadLine());
        for (int a = 0; a < n; a++)
        {
            string[] input = Console.ReadLine().Split();
            string action = input[0];
            string vehicleType = input[1];
            double actionAmount = double.Parse(input[2]);

            Vehicle vehicle = null;

            if (vehicleType == "Car")
            {
                vehicle = car;
            }
            else if (vehicleType == "Truck")
            {
                vehicle = truck;
            }
            else
            {
                vehicle = bus;
            }

            try
            {
                if (action == "Drive")
                {
                    vehicle.Drive(actionAmount);
                }
                else if (action == "Refuel")
                {
                    vehicle.Refuel(actionAmount);
                }
                else if (action == "DriveEmpty")
                {
                    bus.DriveEmpty(actionAmount);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }

    private static Vehicle ReadVehicle()
    {
        string[] info = Console.ReadLine().Split();
        double fuelQuantiy = double.Parse(info[1]);
        double fuelConsumation = double.Parse(info[2]);
        double tankCapacity = double.Parse(info[3]);

        if (fuelQuantiy > tankCapacity)
        {
            fuelQuantiy = 0;
        }

        switch (info[0])
        {
            case "Car":
                return new Car(fuelQuantiy, fuelConsumation, tankCapacity);
            case "Truck":
                return new Truck(fuelQuantiy, fuelConsumation, tankCapacity);
            case "Bus":
                return new Bus(fuelQuantiy, fuelConsumation, tankCapacity);
            default:
                return null;
        }
    }
}