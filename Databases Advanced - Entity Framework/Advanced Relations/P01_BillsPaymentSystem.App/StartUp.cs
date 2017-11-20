using System;
using System.Collections.Generic;
using System.Linq;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Models;

namespace P01_BillsPaymentSystem.App
{
    class StartUp
    {
        static void Main()
        {
            BillPaymentSystemContext dbContext = new BillPaymentSystemContext();
            dbContext.Database.EnsureCreated();

            // 02. Seed Some Dat
            Seed(dbContext);

            // 3. User Details
            int userId = int.Parse(Console.ReadLine());
            PrintUserDetails(dbContext, userId);
        }

        static void Seed(BillPaymentSystemContext dbContext)
        {
            BankAccount[] bankAccounts = new BankAccount[]
            {
                new BankAccount
                {
                    Balance = 2000m,
                    BankName = "Unicredit Bulbank",
                    SwiftCode = "UNCRBGSF"

                },
                new BankAccount
                {
                    Balance = 1000m,
                    BankName = "First Investment Bank",
                    SwiftCode = "FINVBGSF"
                },
            };

            CreditCard[] creditCards = new CreditCard[]
            {
                new CreditCard
                {
                    ExpirationDate = new DateTime(2050, 5, 10),
                    Limit = 2000000m,
                    MoneyOwned = 563594m
                }
            };

            User[] users = new User[]
            {
                new User
                {
                    FirstName = "Boiko",
                    LastName = "NeBorisoff",
                    Password = "DupkiPoPutishtata",
                    Email = "boyko@abv.bg"
                }
            };

            PaymentMethod[] paymentMethods = new PaymentMethod[]
            {
                new PaymentMethod
                {
                    Type = PaymentMethodType.BankAccount,
                    UserId = 1,
                    BankAccountId = 1,
                },
                new PaymentMethod
                {
                    Type = PaymentMethodType.CreditCard,
                    UserId = 1,
                    CreditCardId = 1
                }
            };

            dbContext.AddRange(users);
            dbContext.SaveChanges();

            dbContext.AddRange(bankAccounts);
            dbContext.SaveChanges();

            dbContext.AddRange(creditCards);
            dbContext.SaveChanges();

            dbContext.AddRange(paymentMethods);
            dbContext.SaveChanges();
        }

        static void PrintUserDetails(BillPaymentSystemContext dbContext, int userId)
        {
            var userInfo = dbContext.Users
                .Where(u => u.UserId == userId)
                .Select(u => new
                {
                    Name = $"{u.FirstName} {u.LastName}",
                    BankAccounts = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                        .Select(pm => pm.BankAccount)
                        .ToArray(),
                    CreditCards = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.CreditCard)
                        .Select(pm => pm.CreditCard)
                        .ToArray()
                })
                .FirstOrDefault();

            if (userInfo == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
            }
            else
            {
                Console.WriteLine("User: " + userInfo.Name);
                Console.WriteLine("Bank Accounts:");
                PrintBankAccounts(userInfo.BankAccounts);
                Console.WriteLine("Credit Cards:");
                PrintCreditCards(userInfo.CreditCards);
            }
        }

        static void PrintBankAccounts(IEnumerable<BankAccount> accounts)
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"-- ID: {account.BankAccountId}");
                Console.WriteLine($"--- Balance: {account.Balance}");
                Console.WriteLine($"--- Bank: {account.BankName}");
                Console.WriteLine($"--- SWIFT: {account.SwiftCode}");
            }
        }

        static void PrintCreditCards(IEnumerable<CreditCard> creditCards)
        {
            foreach (var creditCard in creditCards)
            {
                Console.WriteLine($"-- ID: {creditCard.CreditCardId}");
                Console.WriteLine($"--- Limit: {creditCard.Limit}");
                Console.WriteLine($"--- Money Owed: {creditCard.MoneyOwned}");
                Console.WriteLine($"--- Limit Left: {creditCard.LimitLeft}");
                Console.WriteLine($"--- Expiration Date: {creditCard.ExpirationDate:yyyy/MM}");
            }
        }
    }
}
