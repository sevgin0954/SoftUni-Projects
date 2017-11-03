using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        string pizzaName = Console.ReadLine().Split()[1];
        // Read doughInfo
        string[] doughInfo = Console.ReadLine().Split();
        string flourType = doughInfo[1];
        string bakingTechnique = doughInfo[2];
        double weight = double.Parse(doughInfo[3]);
        Dough dough;
        Pizza pizza;
        try
        {
            dough = new Dough(flourType, bakingTechnique, weight);
            pizza = new Pizza(pizzaName, dough);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            return;
        }

        while (true)
        {
            string[] toppingInfo = Console.ReadLine().Split();
            if (toppingInfo[0] == "END")
            {
                break;
            }
            string toppingType = toppingInfo[1];
            double toppingWeight = double.Parse(toppingInfo[2]);

            try
            { 
                Topping topping = new Topping(toppingType, toppingWeight);
                pizza.Addtopping(topping);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
        }

        Console.WriteLine($"{pizzaName} - {pizza.CalculateTotalCalories():f2} Calories.");
    }
}

