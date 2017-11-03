using System;
using System.Collections.Generic;

class Person
{
    private string name;
    private decimal balance;
    private List<Product> products;

    public Person(string name, decimal money)
    {
        Balance = money;
        Name = name;
        Products = new List<Product>();
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
    public decimal Balance
    {
        get
        {
            return balance;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            balance = value;
        }
    }
    public List<Product> Products
    {
        get
        {
            return products;
        }
        set
        {
            products = value;
        }
    }

    public void BuyProduct(Product product)
    {
        decimal productPrice = product.Price;

        if (productPrice > balance)
        {
            throw new ArgumentException($"{Name} can't afford {product.Name}");
        }

        products.Add(product);
        balance -= productPrice;
    }
}
