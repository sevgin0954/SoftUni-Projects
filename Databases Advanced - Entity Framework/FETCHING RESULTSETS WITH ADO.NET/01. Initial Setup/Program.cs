using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        var connectionString = new SqlConnectionStringBuilder()
        {
            ["Server"] = "DESKTOP-4FKVBUR\\SQLEXPRESS",
            ["Integrated Security"] = "true"
        };
        SqlConnection sqlConnection = new SqlConnection(connectionString.ToString());

        sqlConnection.Open();
        using (sqlConnection)
        {
            string commandText = "CREATE DATABASE MinionsDB";
            ExecuteSqlCommand(commandText, sqlConnection);
        }

        connectionString["database"] = "MinionsDB";
        sqlConnection.ConnectionString = connectionString.ToString();
        sqlConnection.Open();

        using (sqlConnection)
        {
            string createCounties =
                "CREATE TABLE Countries (" +
                "Id INT PRIMARY KEY IDENTITY," +
                "Name NVARCHAR(30) NOT NULL" +
                ")";

            string createTowns =
                "CREATE TABLE Towns (" +
                "Id INT PRIMARY KEY IDENTITY," +
                "Name NVARCHAR(30) NOT NULL," +
                "CountryId INT FOREIGN KEY REFERENCES Countries(Id)" +
                ")";

            string createMinions =
                "CREATE TABLE Minions (" +
                "Id INT PRIMARY KEY IDENTITY," +
                "Name NVARCHAR(30) NOT NULL," +
                "Age INT CHECK(Age > 0) NOT NULL," +
                "TownId INT FOREIGN KEY REFERENCES Towns(Id)" +
                ")";

            string createEvilnessFactors =
                "CREATE TABLE EvilnessFactors (" +
                "Id INT PRIMARY KEY IDENTITY," +
                "Name NVARCHAR(30) NOT NULL CHECK(Name IN ('super good', 'good', 'bad', 'evil', 'super evil'))" +
                ")";

            string createVillains =
                "CREATE TABLE Villains (" +
                "Id INT PRIMARY KEY IDENTITY," +
                "Name NVARCHAR(30) NOT NULL," +
                "EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id)" +
                ")";

            string createMinionsVillains =
                "CREATE TABLE MinionsVillains (" +
                "MinionId INT FOREIGN KEY REFERENCES Minions(Id)," +
                "VillainId INT FOREIGN KEY REFERENCES Villains(Id)" +
                "" +
                "CONSTRAINT PK_MinionId_VillainId PRIMARY KEY(MinionId, VillainId)" +
                ")";

            ExecuteSqlCommand(createCounties, sqlConnection);
            ExecuteSqlCommand(createTowns, sqlConnection);
            ExecuteSqlCommand(createMinions, sqlConnection);
            ExecuteSqlCommand(createEvilnessFactors, sqlConnection);
            ExecuteSqlCommand(createVillains, sqlConnection);
            ExecuteSqlCommand(createMinionsVillains, sqlConnection);

            // Inserting Values
            string insertCountries = "INSERT INTO Countries VALUES " +
                "('Bulgaria'), ('United Kingdom'), ('United States of America'), ('France')";

            string insertTowns = "INSERT INTO Towns (Name, CountryId) VALUES " +
                "('Sofia',1), ('Burgas',1), ('Varna', 1), ('London', 2),('Liverpool', 2),('Ocean City', 3),('Paris', 4)";

            string insertMinions = "INSERT INTO Minions (Name, Age, TownId) VALUES " +
                "('bob',10,1), ('kevin',12,2),('stuart',9,3), ('rob',22,3), ('michael',5,2),('pep',3,2)";

            string insertEvilnessFactors = "INSERT INTO EvilnessFactors VALUES " +
                "('Super Good'), ('Good'), ('Bad'), ('Evil'), ('Super Evil')";

            string insertVillains = "INSERT INTO Villains (Name, EvilnessFactorId) VALUES " +
                "('Gru', 2), ('Victor', 4),('Simon Cat', 3),('Pusheen', 1),('Mammal', 5)";
            string insertMinionsVillains = "INSERT INTO MinionsVillains VALUES " +
                "(1, 2), (3, 1), (1, 3), (3, 3), (4, 1), (2, 2), (1, 1), (3, 4), (1, 4), (1, 5), (5, 1)";

            ExecuteSqlCommand(insertCountries, sqlConnection);
            ExecuteSqlCommand(insertTowns, sqlConnection);
            ExecuteSqlCommand(insertMinions, sqlConnection);
            ExecuteSqlCommand(insertEvilnessFactors, sqlConnection);
            ExecuteSqlCommand(insertVillains, sqlConnection);
            ExecuteSqlCommand(insertMinionsVillains, sqlConnection);
        }
    }

    static void ExecuteSqlCommand(string commandText, SqlConnection sqlConnection)
    {
        SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
        sqlCommand.ExecuteNonQuery();
    }
}
