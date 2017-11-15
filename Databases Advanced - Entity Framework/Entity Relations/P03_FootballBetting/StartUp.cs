using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    class StartUp
    {
        static void Main()
        {
            FootballBettingContext dbContext = new FootballBettingContext();
            dbContext.Database.EnsureCreated();
        }
    }
}
