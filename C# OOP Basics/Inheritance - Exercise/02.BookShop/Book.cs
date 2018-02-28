using System;

public class Book
{
    string title;
    string author;
    decimal price;

    public Book(string author, string title, decimal price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public string Title
    {
        get => title;
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            title = value;
        }
    }

    public string Author
    {
        get => author;
        protected set
        {
            string[] firstSecondName = value.Split();
            if (firstSecondName.Length == 2 && char.IsDigit(firstSecondName[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }

            author = value;
        }
    }

    public virtual decimal Price
    {
        get => price;
        protected set
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
        return $"Type: {GetType().Name} {Environment.NewLine}" + 
            $"Title: {Title} {Environment.NewLine}" +
            $"Author: {Author} {Environment.NewLine}" + 
            $"Price: {Price:f2}";
    }
}