using System;
using System.Linq;

public class Smartphone : ICalleble, IBrowseble
{
    public void Browse(string address)
    {
        if (address.Any(ch => char.IsDigit(ch)))
        {
            throw new ArgumentException("Invalid URL!");
        }

        Console.WriteLine($"Browsing: {address}!");
    }

    public void Call(string phoneNumber)
    {
        if (phoneNumber.Any(ch => char.IsDigit(ch) == false))
        {
            throw new ArgumentException("Invalid number!");
        }

        Console.WriteLine($"Calling... {phoneNumber}");
    }
}