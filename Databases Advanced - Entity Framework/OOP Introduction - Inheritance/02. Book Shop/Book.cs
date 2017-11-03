using System;

class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    public string Author
    {
        get
        {
            return author;
        }
        set
        {
            string[] name = value.Split();
            if (name.Length == 2)
            {
                if (char.IsDigit(name[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }

            author = value;
        }
    }

    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            title = value;
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
                throw new ArgumentException("Price not valid!");
            }

            price = value;
        }
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name}" + Environment.NewLine +
            $"Title: {Title}" + Environment.NewLine +
            $"Author: {Author}" + Environment.NewLine +
            $"Price: {Price:f2}";
    }

}

