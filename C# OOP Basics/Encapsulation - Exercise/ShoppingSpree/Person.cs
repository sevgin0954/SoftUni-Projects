using System.Collections.Generic;

public class Person
{
    string name;
    decimal money;
    List<Product> products = new List<Product>();

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
    }

    public string Name
    {
        get { return name; }
        set
        {
            InputValidator.ValidateName(value);
            name = value;
        }
    }

    public decimal Money
    {
        get { return money; }
        set
        {
            InputValidator.ValidateMoney(value);
            money = value;
        }
    }

    public void BuyProduct(Product product)
    {
        if (Money - product.Price < 0)
        {
            throw new System.ArgumentException($"{Name} can't afford {product.Name}");
        }

        Money -= product.Price;
        products.Add(product);
    }

    public override string ToString()
    {
        string output = Name + " - ";

        if (products.Count == 0)
        {
            output += "Nothing bought";
        }
        else
        {
            output += string.Join(", ", products);
        }

        return output;
    }
}