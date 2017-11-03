using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder()
        {
            ["Server"] = "DESKTOP-4FKVBUR\\SQLEXPRESS",
            ["Database"] = "MinionsDB",
            ["Integrated Security"] = "true"
        };
        SqlConnection sqlConnection = new SqlConnection(connectionString.ToString());

        sqlConnection.Open();
        using (sqlConnection)
        {
            string villainsMinionsCountQuery =
                "SELECT v.Name, COUNT(m.Id) AS MinionsCount FROM Villains AS v " +
                "JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                "JOIN Minions AS m ON mv.MinionId = m.Id " +
                "GROUP BY v.Name " +
                "ORDER BY MinionsCount DESC ";

            SqlCommand sqlCommand = new SqlCommand(villainsMinionsCountQuery, sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["Name"] + " - " + reader["MinionsCount"]);
            }
        }
    }
}
