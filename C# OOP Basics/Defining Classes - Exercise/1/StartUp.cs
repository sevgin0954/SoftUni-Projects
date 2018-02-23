using System;
using System.Linq;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        // 03. Oldest Family Member
        //OldestFamilyMember();

        // 04. Opinion Poll
        //OpinionPoll();

        // 06. Company Roster
        //CompanyRoster();

        // 07. Speed Racing
        //SpeedRacing();
    }

    static void OldestFamilyMember()
    {
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int a = 0; a < n; a++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person(name, age);
            family.AddMembers(person);
        }

        Console.WriteLine(family.GetOldestMember());
    }

    static void OpinionPoll()
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();

        for (int a = 0; a < n; a++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person(name, age);
            persons.Add(person);
        }

        persons = persons.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();

        foreach (Person person in persons)
        {
            Console.WriteLine(person);
        }
    }

    static void CompanyRoster()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, List<Employee>> departmentEmployees = new Dictionary<string, List<Employee>>();

        for (int a = 0; a < n; a++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            decimal salary = decimal.Parse(input[1]);
            string position = input[2];
            string department = input[3];

            Employee employee = new Employee(name, salary, position, department);

            if (input.Length == 5)
            {
                if (int.TryParse(input[4], out int age))
                {
                    employee.Age = age;
                }
                else
                {
                    employee.Email = input[4];
                }
            }
            if (input.Length == 6)
            {
                employee.Age = int.Parse(input[5]);
                employee.Email = input[4];
            }

            if (departmentEmployees.ContainsKey(department) == false)
            {
                departmentEmployees[department] = new List<Employee>();
            }

            departmentEmployees[department].Add(employee);
        }

        var hightestPayingDepartment = departmentEmployees
            .OrderByDescending(d => d.Value.Sum(e => e.Salary)).First();


        Console.WriteLine($"Highest Average Salary: {hightestPayingDepartment.Key}");

        foreach (var employee in hightestPayingDepartment.Value.OrderByDescending(p => p.Salary))
        {
            Console.WriteLine(employee);
        }
    }

    static void SpeedRacing()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, Car> modelsCars = new Dictionary<string, Car>();

        for (int a = 0; a < n; a++)
        {
            string[] input = Console.ReadLine().Split();
            string model = input[0];
            float fuelAmaount = float.Parse(input[1]);
            float fuelConsumation = float.Parse(input[2]);

            Car car = new Car(model, fuelAmaount, fuelConsumation);
            modelsCars[model] = car;
        }

        while (true)
        {
            string[] input = Console.ReadLine().Split();

            if (input[0] == "End")
            {
                break;
            }

            string carModel = input[1];
            float distance = float.Parse(input[2]);

            try
            {
                modelsCars[carModel].Drive(distance);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        foreach (var modelCar in modelsCars)
        {
            Console.WriteLine(modelCar.Value);
        }
    }
}