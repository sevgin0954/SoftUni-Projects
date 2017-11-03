using System;
using System.Linq;
using System.Collections.Generic;

class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings = new List<Topping>();

    public Pizza(string name, Dough dough)
    {
        Name = name;
        Dough = dough;
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    public List<Topping> Toppings
    {
        get
        {
            return toppings;
        }
        set
        {
            if (value.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings = value; // comment this
        }
    }

    public Dough Dough
    {
        get
        {
            return dough;
        }
        set
        {
            dough = value;
        }
    }

    public void Addtopping(Topping topping)
    {
        if (Toppings.Count() == 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        Toppings.Add(topping);
    }

    public double CalculateTotalCalories()
    {
        return dough.CalculateCalories() + toppings.Sum(t => t.CalculateCalorys());
    }
}
