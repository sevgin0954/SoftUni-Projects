using System;

class Product
{
    private string name;
    private decimal price;

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }
    public decimal Price
    {
        get
        {
            return price;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price cannot be zero or negative");
            }
            price = value;
        }
    }

    public override string ToString()
    {
        return Name;
    }
}
