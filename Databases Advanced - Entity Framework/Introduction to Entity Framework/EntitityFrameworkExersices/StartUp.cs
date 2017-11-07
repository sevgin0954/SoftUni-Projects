using System;
using System.Linq;
using EntitityFrameworkExersices.Data;
using EntitityFrameworkExersices.Data.Models;

namespace EntitityFrameworkExersices
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            // 03. Employees Full Information
            PrintEmployeeesFullInfo(context);

            // 04. Employees with Salary Over 50 000
            PrintEmpployeesWithSalaryOver(context, 50000);

            // 05. Employees from Research and Development
            PrintEmployeesFromDepartment(context, "Research and Development");

            // 06. Adding a New Address and Updating Employee
            AddAddress(context, "Vitoshka 15", 4);
            int addressId = FindAddressId(context, "Vitoshka 15");
            ChangeEmployeeAddress(context, "Nakov", addressId);

            PrintAddressTextForFirst10Employees(context);

        }

        static void PrintEmployeeesFullInfo(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.MiddleName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:f2}");
            }
        }

        static void PrintEmpployeesWithSalaryOver(SoftUniContext context, decimal minSalary)
        {
            var employeesFistName = context.Employees
                .Where(e => e.Salary > minSalary)
                .Select(e => e.FirstName)
                .OrderBy(e => e);

            foreach (var emp in employeesFistName)
            {
                Console.WriteLine(emp);
            }
        }

        static void PrintEmployeesFromDepartment(SoftUniContext context, string department)
        {
            var employeesInfo = context.Employees
                .Where(e => e.Department.Name == department)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName, 
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            foreach (var emp in employeesInfo)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} from {emp.Name} - ${emp.Salary:f2}");
            }
        }

        static void AddAddress(SoftUniContext context, string addressName, int townId)
        {
            Address address = new Address()
            {
                AddressText = addressName,
                TownId = townId
            };
            context.Addresses.Add(address);

            context.SaveChanges();
        }

        static int FindAddressId(SoftUniContext context, string addressName)
        {
            return context.Addresses.Where(a => a.AddressText == addressName).Select(a => a.AddressId).FirstOrDefault();
        }

        static void ChangeEmployeeAddress(SoftUniContext context, string lastName, int addressId)
        {
            context.Employees
                .Where(e => e.LastName == lastName)
                .FirstOrDefault().AddressId = addressId;

            context.SaveChanges();
        }

        static void PrintAddressTextForFirst10Employees(SoftUniContext context)
        {
            string[] adrressesTexts = context.Employees
                .OrderBy(e => -e.AddressId)
                .Take(10)
                .Select(db => db.Address.AddressText)
                .ToArray();

            foreach (string addressText in adrressesTexts)
            {
                Console.WriteLine(addressText);
            }
        }
    }
}
