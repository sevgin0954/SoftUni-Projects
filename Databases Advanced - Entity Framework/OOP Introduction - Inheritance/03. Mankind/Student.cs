using System;
using System.Linq;

class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get
        {
            return facultyNumber;
        }
        set
        {
            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            if (value.Any(x => !char.IsLetterOrDigit(x)))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + Environment.NewLine +
            $"Faculty number: {FacultyNumber}";
    }
}