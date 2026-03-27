using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TB5.ConsoleApp.DapperSample.DapperSample
{
    public class ProductCategoryDapperService
    {
        private string connectionString = "Data Source = MSI; Initial Catalog = Batch5MiniPOS; User ID = sa; Password = sasa@123; Trust Server Certificate = true;";

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_ProductCategory]
           ([ProductCategoryName])
            VALUES
           (@ProductCategoryName)";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new
            {
                ProductCategoryName = "Electronics"
            });

            string message = result > 0 ? "Product category created successfully." : "Failed to create product category.";
            Console.WriteLine(message);
        }

        public void Read()
        {
            string query = "SELECT * FROM Tbl_ProductCategory";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            List<Tbl_ProductCategory> lst = connection.Query<Tbl_ProductCategory>(query).ToList();

            foreach (Tbl_ProductCategory item in lst)
            {
                Console.WriteLine($"ID: {item.ProductCategoryId}, Name: {item.ProductCategoryName}");
            }
        }

        public void Edit()
        {
            string query = "SELECT * FROM Tbl_ProductCategory WHERE ProductCategoryId = @ProductCategoryId";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            var item = connection.Query<Tbl_ProductCategory>(query, new { ProductCategoryId = 1 }).FirstOrDefault();

            if (item == null)
            {
                Console.WriteLine("Product category not found.");
                return;
            }

            Console.WriteLine($"ID: {item.ProductCategoryId}, Name: {item.ProductCategoryName}");
        }

        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_ProductCategory]
                     SET [ProductCategoryName] = @ProductCategoryName
                     WHERE [ProductCategoryId] = @ProductCategoryId";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new
            {
                ProductCategoryId = 1,
                ProductCategoryName = "Mobile Phones"
            });

            string message = result > 0 ? "Product category updated successfully." : "Failed to update product category.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            string query = "DELETE FROM [dbo].[Tbl_ProductCategory] WHERE [ProductCategoryId] = @ProductCategoryId";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new { ProductCategoryId = 1 });

            string message = result > 0 ? "Product category deleted successfully." : "Failed to delete product category.";
            Console.WriteLine(message);
        }
    }

    public class Tbl_ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
    }
}
