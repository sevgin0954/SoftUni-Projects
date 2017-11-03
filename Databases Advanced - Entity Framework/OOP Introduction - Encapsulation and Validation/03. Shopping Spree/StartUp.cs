using System;
using System.Linq;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        string[] personsMoney = Console.ReadLine().Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string[] productsPrice = Console.ReadLine().Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        List<Person> persons = new List<Person>();
        List<Product> products = new List<Product>();
        try
        {
            AddPeoples(personsMoney, persons);
            AddProducts(productsPrice, products);
            BuyProducts(persons, products);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            return;
        }

        foreach (Person person in persons)
        {
            if (person.Products.Count() == 0)
            {
                Console.WriteLine($"{person.Name} - Nothing bought");
                continue;
            }
            Console.WriteLine(person.Name + " - " + string.Join(", ", person.Products));
        }
    }

    static void AddPeoples(string[] personsMoney, List<Person> persons)
    {
        for (int a = 0; a < personsMoney.Length; a++)
        {
            string[] personMoney = personsMoney[a].Split('=');
            string personName = personMoney[0];
            decimal money = decimal.Parse(personMoney[1]);

            Person person = new Person(personName, money);
            persons.Add(person);
        }
    }
    
    static void AddProducts(string[] productsPrice, List<Product> products)
    {
        for (int a = 0; a < productsPrice.Length; a++)
        {
            string[] poductPrice = productsPrice[a].Split('=');
            string productName = poductPrice[0];
            decimal price = decimal.Parse(poductPrice[1]);
            Product product = new Product(productName, price);
            products.Add(product);
        }
    }

    static void BuyProducts(List<Person> persons, List<Product> products)
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

            Product currentProduct = products.FirstOrDefault(p => p.Name == productName);
            Person currentPerson = persons.FirstOrDefault(p => p.Name == personName);

            try
            {
                currentPerson.BuyProduct(currentProduct);
                Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
