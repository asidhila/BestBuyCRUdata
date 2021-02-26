using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BestBuyCRUDdata
{
      class Program
    {
        static void Main(string[] args)
        {
            
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string ConnString = config.GetConnectionString("DefaultConnection");

            IDbConnection connection = new MySqlConnection(ConnString);

            var repo = new DapperProductRepository(connection);

            var products = repo.GetAllProducts();

            foreach(var prod in products)
            {
                Console.WriteLine($"{prod.ProductionID} {prod.Name}");
            }

            
        }
    }
}
