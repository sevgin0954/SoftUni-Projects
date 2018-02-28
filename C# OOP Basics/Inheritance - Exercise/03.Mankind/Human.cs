using System;

public class Human
{
    string firstName;
    string lastName;

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName
    {
        get => firstName;
        set
        {
            ValidateInput.ValidateName("firstName", value);

            firstName = value;
        }
    }

    public string LastName
    {
        get => lastName;
        set
        {
            ValidateInput.ValidateName("lastName", value);

            lastName = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {FirstName}" + Environment.NewLine +
            $"Last Name: {LastName}";
    }
}