using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string townName = Console.ReadLine();
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
            string updateCommand =
                "UPDATE t " +
                "SET t.Name = UPPER(t.Name) " +
                "FROM Towns AS t " +
                "JOIN Countries AS c ON t.CountryId = c.Id " +
                "WHERE c.Name = @TownName";

            SqlCommand command = new SqlCommand(updateCommand, connection);
            command.Parameters.AddWithValue("@TownName", townName);
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine($"{rowsAffected} town names were affected.");

                // Select Affected Towns
                string selectTownsQuery =
                    "SELECT t.Name FROM Towns AS t " +
                    "JOIN Countries AS c ON t.CountryId = c.Id " +
                    "WHERE c.Name = @TownName";
                command = new SqlCommand(selectTownsQuery, connection);
                command.Parameters.AddWithValue("@TownName", townName);

                // Print Affected Towns
                SqlDataReader reader = command.ExecuteReader();
                bool isFirstRow = true;
                Console.Write("[");
                while (reader.Read())
                {
                    if (isFirstRow == false)
                    {
                        Console.Write(", ");
                    }
                    Console.Write(reader["Name"]);
                    isFirstRow = false;
                }
                Console.Write("]");
            }
            else
            {
                Console.WriteLine("No town names were affected.");
            }
        }
    }
}