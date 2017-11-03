using System;

class Topping
{
    private string type;
    private double weight;

    public Topping(string type, double weight)
    {
        Type = type;
        Weight = weight;
    }

    public string Type
    {
        get
        {
            return type;
        }
        set
        {
            if (value.ToLower() != "meat"
                && value.ToLower() != "veggies"
                && value.ToLower() != "cheese"
                && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    public double Weight
    {
        get
        {
            return weight;
        }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public double CalculateCalorys()
    {
        double typeModifier = 0.9;
        switch (type.ToLower())
        {
            case "meat":
                typeModifier = 1.2;
                break;
            case "veggies":
                typeModifier = 0.8;
                break;
            case "cheese":
                typeModifier = 1.1;
                break;
        }

        return 2 * weight * typeModifier;
    }
}
