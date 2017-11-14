using P03_SalesDatabase.Data;

namespace P03_SalesDatabase
{
    class StartUp
    {
        static void Main()
        {
            SalesContext context = new SalesContext();
            context.Database.EnsureCreated();
        }
    }
}
