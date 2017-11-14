using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase
{
    class StatrUp
    {
        static void Main()
        {
            var dbContext = new HospitalContext();
            dbContext.Database.EnsureCreated();
        }
    }
}
