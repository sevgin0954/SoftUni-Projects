using System;
using System.Linq;
using System.Globalization;
using EntitityFrameworkExersices.Data;
using EntitityFrameworkExersices.Data.Models;
using Microsoft.EntityFrameworkCore;

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
            
            // 07. Employees and Projects
            Print30EmployeesWithProjects(context, 2001, 2003);
            
            // 08. Addresses by Town
            PrintTop10AdressesOrdered(context);
            
            // 09. Employee 147
            GetEmployeeInfoById(context, 147);
            
            // 10.	Departments with More Than 5 Employees
            PrintDepartmentWithMoreThanEmployees(context, 5);
            
            // 11. Find Latest 10 Projects
            FindLatestNStartedProjects(context, 10);
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

        static void Print30EmployeesWithProjects(SoftUniContext context, int startYear, int endYear)
        {
            var employeesProjects = context.Employees
                .Where
                (
                    e => e.EmployeesProjects.Any
                    (
                        ep => ep.Project.StartDate.Year >= startYear && ep.Project.StartDate.Year <= endYear
                    )
                )
                .Take(30)
                .Select(e => new
                {
                    employeeName = $"{e.FirstName} {e.LastName}",
                    managerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeesProjects.Select(ep => new
                    {
                        ep.Project.Name,
                        ep.Project.StartDate,
                        ep.Project.EndDate
                    })
                });
            foreach (var employeeProject in employeesProjects)
            {
                Console.WriteLine($"{employeeProject.employeeName} - Manager: {employeeProject.managerName}");
                foreach (var project in employeeProject.Projects)
                {
                    Console.WriteLine($"--{project.Name} - " +
                        $"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - " +
                        $"{(project.EndDate.HasValue ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished")}");
                }
            }
        }

        static void PrintTop10AdressesOrdered(SoftUniContext context)
        {
            var orderedAddresses = context.Addresses
                .Include(a => a.Town)
                .Include(a => a.Employees)
                .OrderByDescending(a => a.Employees.Count())
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10);

            Console.WriteLine();
            foreach (var address in orderedAddresses)
            {
                Console.WriteLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count()} employees");
            }
        }

        static void GetEmployeeInfoById(SoftUniContext context, int employeeId)
        {
            var employeesInfo = context.Employees
                .Where(e => e.EmployeeId == employeeId)
                .Select(e => new
                {
                    name = e.FirstName + " " + e.LastName,
                    e.JobTitle,
                    projects = e.EmployeesProjects.Select(ep => ep.Project).OrderBy(ep => ep.Name)
                });

            foreach (var employeeInfo in employeesInfo)
            {
                Console.WriteLine($"{employeeInfo.name} - {employeeInfo.JobTitle}");
                foreach (var project in employeeInfo.projects)
                {
                    Console.WriteLine(project.Name);
                }
            }
        }

        static void PrintDepartmentWithMoreThanEmployees(SoftUniContext context, int employeesCount)
        {
            var departmentsManagersEmployees = context.Departments
                .Where(d => d.Employees.Count() > employeesCount)
                .Include(d => d.Manager).Include(d => d.Employees)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name);

            foreach (var departmentManagerEmployees in departmentsManagersEmployees)
            {
                string managerFullName = 
                    $"{departmentManagerEmployees.Manager.FirstName} {departmentManagerEmployees.Manager.LastName}";

                Console.WriteLine($"{departmentManagerEmployees.Name} - {managerFullName}");
                foreach (var employees in departmentManagerEmployees.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName))
                {
                    string employeeFullName = $"{employees.FirstName} {employees.LastName}";
                    Console.WriteLine($"{employeeFullName} - {employees.JobTitle}");
                }

                Console.WriteLine(new string('-', 10));
            }
        }

        static void FindLatestNStartedProjects(SoftUniContext context, int projectsCount)
        {
            var lastNProjects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(projectsCount)
                .OrderBy(p => p.Name);

            foreach (var project in lastNProjects)
            {
                Console.WriteLine(project.Name);
                Console.WriteLine(project.Description);
                Console.WriteLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }
        }
    }
}
