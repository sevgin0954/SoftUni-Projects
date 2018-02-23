public class Person
{
    string name;
    int age;

    public Person()
    {
        name = "No name";
        age = 1;
    }

    public Person(int age)
        :this()
    {
        this.age = age;
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public override string ToString()
    {
        return name + " " + age;
    }
}
