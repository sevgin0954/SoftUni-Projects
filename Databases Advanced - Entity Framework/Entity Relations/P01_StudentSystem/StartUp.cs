using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            StudentSystemContext dbContext = new StudentSystemContext();
            dbContext.Database.EnsureCreated();
        }
    }
}
