using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        int villainId = int.Parse(Console.ReadLine());

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
            string deleteFromMVQuery =
                "DELETE FROM MinionsVillains " +
                $"WHERE VillainId = {villainId}";
            SqlCommand command = new SqlCommand(deleteFromMVQuery, connection);
            int deletedMinionsCount = command.ExecuteNonQuery();

            string getVillainNameQuery =
                    "SELECT Name FROM Villains " +
                    $"WHERE Id = {villainId}";
            command = new SqlCommand(getVillainNameQuery, connection);
            string villainName = (string)command.ExecuteScalar();

            string deleteFromVillainsQuery =
                "DELETE FROM Villains " +
                $"WHERE Id = {villainId}";
            command = new SqlCommand(deleteFromVillainsQuery, connection);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                Console.WriteLine("No such villain was found.");
            }
            else
            {
                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{deletedMinionsCount} minions were released.");
            }
        }
    }
}