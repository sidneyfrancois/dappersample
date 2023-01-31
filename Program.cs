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
            
            var category = new Category();
            var insertSql = "INSERT INTO [Category] VALUES(NEWID(), title, url, summary, order, description, featured)";
            
            using (var connection = new SqlConnection(connectionString))
            {
                // Insert new category
                

                // Get all categories
                var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

                foreach (var item in categories)
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }

            Console.WriteLine("Programa finalizado");
        }
    }
}
