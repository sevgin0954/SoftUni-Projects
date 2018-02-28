using System;

public class Person
{
    string name;
    int age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }

            name = value;
        }
    }

    public virtual int Age
    {
        get { return age; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }

            age = value;
        }
    }

    public override string ToString()
    {
        return $"Name: {name}, Age: {age}";
    }
}