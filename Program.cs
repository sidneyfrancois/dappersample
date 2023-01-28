using System;
using BaltaDataAccess.Models;
using Dapper;
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
                var categories = connection.Query<Category>("SELECT [Id] AS [Codigo], [Title] AS [Titulo] FROM [Category]");

                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Codigo} - {category.Titulo}");
                }
            }

            Console.WriteLine("Programa finalizado");
        }
    }
}
