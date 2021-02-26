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

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection connection = new MySqlConnection(connString);

            var repo = new DapperDepartmentRepository(connection);
            var departments = repo.GetAllDepartments();
            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentId} {dept.Name}");
            }

            var rep = new DapperProductRepository(connection);

            var products = rep.GetAllProducts();

            foreach(var prod in products)
            {
                Console.WriteLine($"{prod.ProductionID} {prod.Name}");
            }

            
        }
    }
}
