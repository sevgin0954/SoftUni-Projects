using System;
using System.Linq;

static class ValidateInput
{
    public static void ValidateName(string argument, string name)
    {
        byte minNameLength = (byte)(argument == "lastName" ? 3 : 4);

        if (char.IsUpper(name[0]) == false)
        {
            throw new ArgumentException($"Expected upper case letter! Argument: {argument}");
        }
        if (name.Length < minNameLength)
        {
            throw new ArgumentException($"Expected length at least {minNameLength} symbols! Argument: {argument}");
        }
    }

    public static void ValidateFacultyNumber(string facultyNumber)
    {
        if (facultyNumber.Length < 5 || facultyNumber.Length > 10 || facultyNumber.ToCharArray().All(char.IsLetterOrDigit) == false)
        {
            throw new ArgumentException("Invalid faculty number!");
        }
    }

    public static void ValidateWeekSalary(decimal weekSalary)
    {
        if (weekSalary <= 10)
        {
            throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
        }
    }

    public static void ValidateWorkingHours(decimal workingHours)
    {
        if (workingHours < 1 || workingHours > 12)
        {
            throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
        }
    }
}