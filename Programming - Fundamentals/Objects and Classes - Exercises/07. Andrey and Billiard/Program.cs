using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, decimal> productsPrices = ReadProductsPrices(n);
        List<Client> clients = ReadClientsBills(productsPrices);
        clients = clients.OrderBy(c => c.Name).ToList();
        PrintClientsBills(clients, productsPrices);
    }

    static Dictionary<string, decimal> ReadProductsPrices(int count)
    {
        Dictionary<string, decimal> productsPrices = new Dictionary<string, decimal>();
        for (int a = 0; a < count; a++)
        {
            string[] input = Console.ReadLine().Split('-');
            string product = input[0];
            decimal price = decimal.Parse(input[1]);
            productsPrices[product] = price;
        }
        return productsPrices;
    }


    static List<Client> ReadClientsBills(Dictionary<string, decimal> productsPrices)
    {
        List<Client> clients = new List<Client>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end of clients")
            {
                break;
            }
            string[] splitInput = input.Split('-', ',');
            string name = splitInput[0];
            string product = splitInput[1];
            int quantity = int.Parse(splitInput[2]);
            if (!productsPrices.ContainsKey(product))
            {
                continue;
            }
            Client client = new Client()
            {
                Name = name,
                ProductsQuantitys = new Dictionary<string, int>
                {
                    [product] = quantity
                }
            };
            if (clients.Any(c => c.Name == name))
            {
                Client exitingClient = clients.First(c => c.Name == name);
                if (exitingClient.ProductsQuantitys.ContainsKey(product))
                {
                    exitingClient.ProductsQuantitys[product] += quantity;
                }
                else
                {
                    exitingClient.ProductsQuantitys[product] = quantity;
                }
            }
            else
            {
                clients.Add(client);
            }
        }
        return clients;
    }

    static void PrintClientsBills(List<Client> clients, Dictionary<string, decimal> productsPrices)
    {
        decimal totalBills = 0;
        foreach (Client client in clients)
        {
            decimal currentBill = 0;
            Console.WriteLine(client.Name);
            foreach (KeyValuePair<string, int> productQuantity in client.ProductsQuantitys)
            {
                Console.WriteLine($"-- {productQuantity.Key} - {productQuantity.Value}");
                totalBills += productQuantity.Value * productsPrices[productQuantity.Key];
                currentBill += productQuantity.Value * productsPrices[productQuantity.Key];
            }
            Console.WriteLine($"Bill: {currentBill:f2}");
        }
        Console.WriteLine($"Total bill: {totalBills:f2}");
    }
}

class Client
{
    public string Name { get; set; }
    public Dictionary<string, int> ProductsQuantitys { get; set; }
}