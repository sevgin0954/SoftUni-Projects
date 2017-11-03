using System;
using System.Reflection;

class StartUp
{
    static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }


        int n = int.Parse(Console.ReadLine());
        Family family = new Family();
        for (int a = 0; a < n; a++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);

            Person member = new Person(name, age);
            family.AddMember(member);
        }

        Console.WriteLine(family.GetOldestMember());
    }
}