using System;

class StartUp
{
    static void Main()
    {
        try
        {
            // Read Student Info
            string[] studentInfo = Console.ReadLine().Split();
            string studentFirstName = studentInfo[0];
            string studentLastName = studentInfo[1];
            string facultyNumber = studentInfo[2];
            Student sevgin = new Student(studentFirstName, studentLastName, facultyNumber);

            //Read Workder Info
            string[] workerInfo = Console.ReadLine().Split();
            string workerFirstName = workerInfo[0];
            string workerLastName = workerInfo[1];
            decimal weekSalary = decimal.Parse(workerInfo[2]);
            float workHoursPerDay = float.Parse(workerInfo[3]);
            Worker batBoyko = new Worker(workerFirstName, workerLastName, weekSalary, workHoursPerDay);

            Console.WriteLine(sevgin);
            Console.WriteLine();
            Console.WriteLine(batBoyko);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}
