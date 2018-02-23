public class Employee
{
    string name;
    int age;
    decimal salary;
    string position;
    string department;
    string email;

    public Employee(string name, decimal salary, string position, string department, string email = "n/a", int age = -1)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Department = department;
        Email = email;
        Age = age;
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            age = value;
        }
    }

    public decimal Salary
    {
        get
        {
            return salary;
        }
        set
        {
            salary = value;
        }
    }

    public string Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }

    public string Department
    {
        get
        {
            return department;
        }
        set
        {
            department = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
        }
    }

    public override string ToString()
    {
        return $"{Name} {Salary:f2} {Email} {Age}";
    }
}
