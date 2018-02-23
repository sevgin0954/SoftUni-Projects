using System.Linq;
using System.Collections.Generic;

public class Family
{
    List<Person> members = new List<Person>();

    public void AddMembers(Person member)
    {
        members.Add(member);
    }

    public Person GetOldestMember()
    {
        return members.OrderByDescending(m => m.Age).First();
    }
}