using System;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost;Database=balta;Trusted_Connection=True;TrustServerCertificate=True";
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Conectado");

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }
            }

            Console.WriteLine("Programa finalizado");
        }
    }
}
