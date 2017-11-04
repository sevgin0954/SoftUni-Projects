using System;
using System.Linq;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();
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
            for (int a = 0; a < ids.Length; a++)
            {
                string query =
                "UPDATE Minions " +
                "SET Age += 1, Name = UPPER(Name) " +
                $"WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", ids[a]);
                command.ExecuteNonQuery();
            }

            PrintDatabase("Minions", connection);
        }
    }

    static void PrintDatabase(string database, SqlConnection connection)
    {
        using (connection)
        {
            string query =
                $"SELECT Name, Age FROM {database}";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["Name"] + " " + reader["Age"]);
            }
        }
    }
}