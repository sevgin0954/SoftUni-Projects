using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] laudatoryPhrases = 
        { "Excellent product.",
          "Such a great product.",
          "I always use that product.",
          "Best product of its category.",
          "Exceptional product.",
          "I can’t live without this product."
        };
        string[] events =
        {
            "Now I feel good.",
            "I have succeeded with this product.",
            "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.",
            "I feel great!"
        };
        string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
        string[] citys = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
        Random r = new Random();
        for (int a = 0; a < n; a++)
        {
            int laudatoryIndex = r.Next(0, laudatoryPhrases.Length);
            int eventIndex = r.Next(0, events.Length);
            int authorIndex = r.Next(0, authors.Length);
            int cityIndex = r.Next(0, citys.Length);
            Console.WriteLine($"{laudatoryPhrases[laudatoryIndex]} {events[eventIndex]} {authors[authorIndex]} {citys[cityIndex]}");
        }
    }
}