using System;

class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName
    {
        get
        {
            return firstName;
        }
        set
        {
            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            if (char.IsUpper(value[0]) == false)
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }

            firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            if (char.IsUpper(value[0]) == false) 
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            lastName = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {FirstName}" + Environment.NewLine +
            $"Last Name: {LastName}";
    }
}
