using System.Linq;
using System.Collections.Generic;

class Family
{
    private List<Person> members = new List<Person>();

    public void AddMember(Person person)
    {
        members.Add(person);
    }

    public Person GetOldestMember()
    {
        return members.OrderBy(m => -m.Age).First();
    }
}
