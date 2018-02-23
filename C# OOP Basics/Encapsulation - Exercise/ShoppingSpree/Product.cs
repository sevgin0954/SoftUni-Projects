public class Product
{
    string name;
    decimal price;

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
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

    public decimal Price
    {
        get { return price; }
        set
        {
            InputValidator.ValidateMoney(value);
            price = value;
        }
    }

    public override string ToString()
    {
        return Name;
    }
}