using System;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public double[] Grades { get; set; }
    public double AverageGrade
    {
        get
        {
            return Grades.Sum() / Grades.Length;
        }
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Student[] students = ReadStudents(n);
        students = students.
            Where(s => s.AverageGrade >= 5).
            OrderByDescending(s => s.AverageGrade).
            OrderBy(s => s.Name).
            ToArray();
        PrintStudents(students);
    }

    static Student[] ReadStudents(int count)
    {
        Student[] students = new Student[count];
        for (int a = 0; a < count; a++)
        {
            string[] input = Console.ReadLine().Split();
            double[] grades = input.Skip(1).Select(double.Parse).ToArray();
            students[a] = new Student
            {
                Name = input[0],
                Grades = grades
            };
        }
        return students;
    }

    static void PrintStudents(Student[] students)
    {
        foreach (Student student in students)
        {
            Console.WriteLine($"{student.Name} -> {student.AverageGrade:f2}");
        }
    }
}