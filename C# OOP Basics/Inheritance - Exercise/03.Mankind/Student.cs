using System;

public class Student : Human
{
    string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get => facultyNumber;
        set
        {
            ValidateInput.ValidateFacultyNumber(value);

            facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + 
            Environment.NewLine + $"Faculty number: {facultyNumber}";
    }
}