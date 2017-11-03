using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string[] minionInfo = Console.ReadLine().Split();
        string villainName = Console.ReadLine().Split()[1];

        string minionName = minionInfo[1];

        SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder()
        {
            ["Server"] = "DESKTOP-4FKVBUR\\SQLEXPRESS",
            ["Database"] = "MinionsDB",
            ["Integrated Security"] = "true"
        };
        SqlConnection connection = new SqlConnection(connectionString.ToString());
        connection.Open();

        AddIntoMinions(minionInfo, connection);

        // Check is vilaiin exist and add it into DB if not
        int vilianId = SqlFindRecordId(villainName, "Villains", connection);
        if (vilianId == -1)
        {
            AddIntoVillains(villainName, connection);
            vilianId = SqlFindRecordId(villainName, "Villains", connection);
        }

        int minionId = SqlFindRecordId(minionName, "Minions", connection);

        // Add villain and minion into mapping table MinionsVillains
        AddIntoMinionsVillains(minionId, vilianId, connection);

        connection.Close();
        Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
    }

    static void AddIntoMinions(string[] minionInfo, SqlConnection connection)
    {
        // Minion info
        string minionName = minionInfo[1];
        int minionAge = int.Parse(minionInfo[2]);
        string townName = minionInfo[3];
        int townId = SqlFindRecordId(townName, "Towns", connection);
        // Check is town exist and if not add it
        if (townId == -1)
        {
            AddIntoTowns(townName, connection);
            townId = SqlFindRecordId(townName, "Towns", connection);
        }
        // insert info into Minions table
        string insertQuery =
            "INSERT INTO Minions VALUES " +
            "(@Name, @Age, @TownId)";

        SqlCommand command = new SqlCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@Name", minionName);
        command.Parameters.AddWithValue("@Age", minionAge);
        command.Parameters.AddWithValue("@TownId", townId);

        command.ExecuteNonQuery();
    }

    static void AddIntoVillains(string villainName, SqlConnection connection)
    {
        string addVillainCommand =
            "INSERT INTO Villains VALUES " +
            "(@Name, 4)";
        SqlCommand command = new SqlCommand(addVillainCommand, connection);
        command.Parameters.AddWithValue("@Name", villainName);
        command.ExecuteNonQuery();
        Console.WriteLine($"Villain {villainName} was added to the database.");
    }

    static void AddIntoMinionsVillains(int minionId, int villainId, SqlConnection connection)
    {
        string query =
            "INSERT INTO MinionsVillains VALUES " +
            $"({minionId}, {villainId})";
        SqlCommand command = new SqlCommand(query, connection);
        command.ExecuteNonQuery();
    }

    static void AddIntoTowns(string townName, SqlConnection connection)
    {
        string addTownCommand =
            "INSERT INTO Towns(Name) VALUES " +
            "(@TownName)";
        SqlCommand command = new SqlCommand(addTownCommand, connection);
        command.Parameters.AddWithValue("@TownName", townName);
        command.ExecuteNonQuery();
        Console.WriteLine($"Town {townName} was added to the database.");
    }

    static int SqlFindRecordId(string recordName, string dbName, SqlConnection connection)
    {
        int id = -1;
        dbName.Replace("'", "''");
        string query =
            $"SELECT Id FROM {dbName} " +
            "WHERE Name = @recordName";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@dbName", dbName);
        command.Parameters.AddWithValue("@recordName", recordName);

        id = (int)(command.ExecuteScalar() ?? -1);
        return id;
    }
}
