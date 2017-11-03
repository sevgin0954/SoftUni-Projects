using System;
using System.Linq;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, List<Employee>> departmentsEmployees = new Dictionary<string, List<Employee>>();

        for (int a = 0; a < n; a++)
        {
            string[] input = Console.ReadLine().Split(' ');
            string name = input[0];
            decimal salary = decimal.Parse(input[1]);
            string position = input[2];
            string department = input[3];
            string email = "n/a";
            int age = -1;
            if (input.Length == 5)
            {
                bool isAge = int.TryParse(input[4], out age);
                if (isAge == false)
                {
                    age = -1;
                    email = input[4];
                }
            }
            if (input.Length == 6)
            {
                age = int.Parse(input[5]);
                email = input[4];
            }

            if (departmentsEmployees.ContainsKey(department) == false)
            {
                departmentsEmployees[department] = new List<Employee>();
            }
            Employee sevgin = new Employee(name, salary, position, department, email, age);
            departmentsEmployees[department].Add(sevgin);
        }

        string bestPayingDepartmentName = GetBestPayingDepartment(departmentsEmployees);
        Console.WriteLine($"Highest Average Salary: {bestPayingDepartmentName}");
        PrintEmployeesInfo(departmentsEmployees.
            Where(d => d.Key == bestPayingDepartmentName).
            ToDictionary(k => k.Key, v => v.Value));
    }

    static string GetBestPayingDepartment(Dictionary<string, List<Employee>> departmentsEmployees)
    {
        string bestPayingDepartment = "";
        decimal bestAvgSalary = 0;

        foreach (KeyValuePair<string, List<Employee>> departmentEmployees in departmentsEmployees)
        {
            decimal totalSalary = 0;

            foreach (Employee employee in departmentEmployees.Value)
            {
                totalSalary += employee.Salary;
            }

            decimal avgSalary = totalSalary / departmentEmployees.Value.Count;
            if (avgSalary > bestAvgSalary)
            {
                bestAvgSalary = avgSalary;
                bestPayingDepartment = departmentEmployees.Key; 
            }
        }

        return bestPayingDepartment;
    }

    static void PrintEmployeesInfo(Dictionary<string, List<Employee>> departmentsEmployees)
    {
        foreach (Employee employee in departmentsEmployees.Values.First().OrderBy(e => -e.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }
}