using System;

class Worker : Human
{
    private decimal weekSalary;
    private float workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, float workHoursPerDay)
        : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get
        {
            return weekSalary;
        }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            weekSalary = value;
        }
    }

    public float WorkHoursPerDay
    {
        get
        {
            return workHoursPerDay;
        }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            workHoursPerDay = value;
        }
    }

    decimal CalcSalaryPerHour()
    {
        return WeekSalary / 5 / (decimal)WorkHoursPerDay;
    }

    public override string ToString()
    {
        return base.ToString() + Environment.NewLine + 
            $"Week Salary: {WeekSalary:f2}" + Environment.NewLine +
            $"Hours per day: {WorkHoursPerDay:f2}" + Environment.NewLine +
            $"Salary per hour: {CalcSalaryPerHour():f2}";
    }
}
