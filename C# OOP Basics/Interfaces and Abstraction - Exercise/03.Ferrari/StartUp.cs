using System;

class StartUp
{
    static void Main()
    {
        string driverName = Console.ReadLine();
        string carModel = "488-Spider";

        Ferrari ferrari = new Ferrari()
        {
            DriverName = driverName,
            Model = carModel
        };

        Console.WriteLine($"{ferrari.Model}/{ferrari.UseBrakes()}/{ferrari.PushGas()}/{ferrari.DriverName}");
    }
}
