using System;

class StartUp
{
    static void Main()
    {
        string[] studentInfo = Console.ReadLine().Split();
        string studentFirstName = studentInfo[0];
        string studentLastName = studentInfo[1];
        string studentFacultyNumber = studentInfo[2];

        string[] workerInfo = Console.ReadLine().Split();
        string workerFirstName = workerInfo[0];
        string workerLastName = workerInfo[1];
        decimal weekSalary = decimal.Parse(workerInfo[2]);
        decimal workerWorkingHours = decimal.Parse(workerInfo[3]);

        try
        {
            Student student = new Student(studentFirstName, studentLastName, studentFacultyNumber);
            Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, workerWorkingHours);

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch(ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}