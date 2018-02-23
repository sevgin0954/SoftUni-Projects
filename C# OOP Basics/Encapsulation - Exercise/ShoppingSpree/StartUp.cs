    using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        Dictionary<string, Person> namesPersons = new Dictionary<string, Person>();
        Dictionary<string, Product> namesProducts = new Dictionary<string, Product>();

        try
        {
            ReadPersons(namesPersons);
            ReadProducts(namesProducts);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            return;
        }

        BuyProducts(namesPersons, namesProducts);
        PrintShopings(namesPersons);
    }

    static void ReadPersons(Dictionary<string, Person> namesPersons)
    {
        string[] personsInfos = Console.ReadLine().Split(';');
        
        foreach (string personInfo in personsInfos)
        {
            string[] info = personInfo.Split('=');
            string name = info[0];
            decimal money = decimal.Parse(info[1]);

            if (namesPersons.ContainsKey(name) == false)
            {
                namesPersons[name] = new Person(name, money);
            }
        }
    }

    static void ReadProducts(Dictionary<string, Product> namesProducts)
    {
        string[] input = Console.ReadLine().Split("=;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        for (int a = 0; a < input.Length - 1; a+=2)
        {
            string name = input[a];
            decimal price = decimal.Parse(input[a + 1]);

            if (namesProducts.ContainsKey(name) == false)
            {
                namesProducts[name] = new Product(name, price);
            }
        }
    }

    static void BuyProducts(Dictionary<string, Person> namesPersons, Dictionary<string, Product> namesProducts)
    {
        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "END")
            {
                return;
            }

            string personName = input[0];
            string productName = input[1];
            Person person = namesPersons[personName];
            Product product = namesProducts[productName];

            try
            {
                person.BuyProduct(product);
                Console.WriteLine(personName + " bought " + productName);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }

    static void PrintShopings(Dictionary<string, Person> namesPersons)
    {
        foreach (var namePerson in namesPersons)
        {
            Console.WriteLine(namePerson.Value);
        }
    }
}
