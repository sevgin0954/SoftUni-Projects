using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        int villianId = int.Parse(Console.ReadLine());

        SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder()
        {
            ["Server"] = "DESKTOP-4FKVBUR\\SQLEXPRESS",
            ["Database"] = "MinionsDB",
            ["Integrated Security"] = "true"
        };

        SqlConnection connection = new SqlConnection(connectionString.ToString());

        connection.Open();
        using (connection)
        {
            string villainsMinionsQuery =
                "SELECT v.Name, m.Name AS MinionName, m.Age FROM Villains AS v " +
                "LEFT JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                "LEFT JOIN Minions AS m ON mv.MinionId = m.Id " +
                "WHERE v.Id = @VillianId " +
                "ORDER BY MinionName";

            SqlCommand command = new SqlCommand(villainsMinionsQuery, connection);
            command.Parameters.Add("@VillianId", System.Data.SqlDbType.Int);
            command.Parameters["@VillianId"].Value = villianId;
            SqlDataReader reader = command.ExecuteReader();

            bool isVilianNamePrint = false;
            int count = 1;

            while (reader.Read())
            {
                if (isVilianNamePrint == false)
                {
                    isVilianNamePrint = true;
                    Console.WriteLine($"Villain: {reader["Name"]}");
                }

                if (reader["MinionName"].ToString() == "")
                {
                    Console.WriteLine("(no minions)");
                }
                else
                {
                    Console.WriteLine($"{count++}. {reader["MinionName"]} - {reader["Age"]}");
                }
            }

            if (isVilianNamePrint == false)
            {
                Console.WriteLine($"No villain with ID {villianId} exists in the database.");
            }
        }
    }
}
