using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace BestBuyBestPractices
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

            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperProductRepository(conn);

            Console.WriteLine("Please provide new product name:");

            var name = Console.ReadLine();

            Console.WriteLine("Provide product price");

            var price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Provide the CategoryID");

            var categoryID = Convert.ToInt32(Console.ReadLine());

            repo.CreateProduct(name, price, categoryID);

            var products = repo.GetAllProducts();

            foreach(var prod in products)
            {
                Console.WriteLine(prod.Name);
            }

        }
    }
}
