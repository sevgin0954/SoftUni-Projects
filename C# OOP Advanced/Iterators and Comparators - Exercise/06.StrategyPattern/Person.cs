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
        get => name;
        set { name = value; }
    }

    public int Age
    {
        get => age;
        set { age = value; }
    }
}