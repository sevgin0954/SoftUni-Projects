using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Library lib = new Library
        {
            Name = "sevginLib",
            Books = ReadBooks(n)
        };
        Dictionary<string, decimal> authorsTotalPrices = GetAuthorsInfo(lib);
        authorsTotalPrices = authorsTotalPrices.
            OrderBy(a => a.Key).
            OrderByDescending(a => a.Value).
            ToDictionary(k => k.Key, v => v.Value);
        foreach (KeyValuePair<string, decimal> authorTotalPrice in authorsTotalPrices)
        {
            Console.WriteLine($"{authorTotalPrice.Key} -> {authorTotalPrice.Value:f2}");
        }
    }

    static Book[] ReadBooks(int count)
    {
        Book[] books = new Book[count];
        for (int a = 0; a < count; a++)
        {
            string[] input = Console.ReadLine().Split();
            books[a] = new Book
            {
                Title = input[0],
                Author = input[1],
                Publisher = input[2],
                ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                ISBN = input[4],
                Price = decimal.Parse(input[5])
            };
        }
        return books;
    }

    static Dictionary<string, decimal> GetAuthorsInfo(Library lib)
    {
        Dictionary<string, decimal> authorsInfo = new Dictionary<string, decimal>();
        foreach (Book book in lib.Books)
        {
            if (!authorsInfo.ContainsKey(book.Author))
            {
                authorsInfo[book.Author] = 0;
            }
            authorsInfo[book.Author] += book.Price;
        }
        return authorsInfo;
    }
}

class AuthorInfo
{
    public string Name { get; set; }
    public decimal TotalPrice { get; set; }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ISBN { get; set; }
    public decimal Price { get; set; }
}

class Library
{
    public string Name { get; set; }
    public Book[] Books { get; set; } 
}
