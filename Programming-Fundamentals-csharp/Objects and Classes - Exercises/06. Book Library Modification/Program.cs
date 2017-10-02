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
        Dictionary<string, DateTime > titlesDates = GetTitlesDates(lib);
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
        titlesDates = titlesDates.
            Where(a => a.Value > date).
            OrderBy(a => a.Key).
            OrderBy(a => a.Value).
            ToDictionary(k => k.Key, v => v.Value);
        foreach (KeyValuePair<string, DateTime> titleDate in titlesDates)
        {
            Console.WriteLine($"{titleDate.Key} -> {titleDate.Value:dd.MM.yyyy}");
        }
    }

    static Dictionary<string, DateTime> GetTitlesDates(Library lib)
    {
        Dictionary<string, DateTime> titlesDates = new Dictionary<string, DateTime>();
        foreach (Book book in lib.Books)
        {
            titlesDates[book.Title] = book.ReleaseDate; 
        }
        return titlesDates;
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
