using System;

public class Worker : Human
{
    decimal weekSalary;
    decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHoursPerDay)
        : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        WorkHoursPerDay = workingHoursPerDay;
    }

    public decimal WeekSalary
    {
        get => weekSalary;
        set
        {
            ValidateInput.ValidateWeekSalary(value);

            weekSalary = value;
        }
    }

    public decimal WorkHoursPerDay
    {
        get => workHoursPerDay;
        set
        {
            ValidateInput.ValidateWorkingHours(value);

            workHoursPerDay = value;
        }
    }

    public decimal CalculateSalaryPerHour()
    {
        decimal salaryPerHour = 0;

        salaryPerHour = weekSalary / 5 / WorkHoursPerDay;

        return salaryPerHour;
    }

    public override string ToString()
    {
        return base.ToString() +
            Environment.NewLine + $"Week Salary: {WeekSalary:f2}" + Environment.NewLine +
            $"Hours per day: {WorkHoursPerDay:f2}" + Environment.NewLine +
            $"Salary per hour: {CalculateSalaryPerHour():f2}";
    }
}