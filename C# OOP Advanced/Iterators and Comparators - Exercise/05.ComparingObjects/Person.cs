using System;

public class Person : IComparable<Person>
{
    string name;
    int age;
    string townName;

    public Person(string name, int age, string townName)
    {
        Name = name;
        Age = age;
        TownName = townName;
    }

    public string Name
    {
        get => name;
        set { name = value; }
    }

    public int Age
    {
        get => age;
        set { age = value; }
    }

    public string TownName
    {
        get => townName;
        set { townName = value; }
    }

    public int CompareTo(Person other)
    {
        if (this.Name.CompareTo(other.Name) == 0)
        {
            if (this.Age.CompareTo(other.Age) == 0)
            {
                return this.TownName.CompareTo(other.TownName);
            }
            else
            {
                return this.Age.CompareTo(other.Age);
            }
        }
        else
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
