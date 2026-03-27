using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TB5.ConsoleApp.DapperSample.DapperSample
{
    public class SaleDapperService
    {
        private string connectionString = "Data Source = MSI; Initial Catalog = Batch5MiniPOS; User ID = sa; Password = sasa@123; Trust Server Certificate = true;";

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Sale]
           ([ProductID]
           ,[Price]
           ,[Quantity]
           ,[SaleDate])
            VALUES
           (@ProductID,
           @Price,
           @Quantity,
           @SaleDate)";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new
            {
                ProductID = 1,
                Price = 1000,
                Quantity = 2,
                SaleDate = DateTime.Now
            });

            string message = result > 0 ? "Sale record created successfully." : "Failed to create sale record.";
            Console.WriteLine(message);
        }

        public void Read()
        {
            string query = "SELECT * FROM Tbl_Sale";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            List<Tbl_Sale> lst = connection.Query<Tbl_Sale>(query).ToList();

            foreach (Tbl_Sale item in lst)
            {
                Console.WriteLine($"SaleID: {item.SaleID}, ProductID: {item.ProductID}, Price: {item.Price}, Quantity: {item.Quantity}, Date: {item.SaleDate}");
            }
        }

        public void Edit()
        {
            string query = "SELECT * FROM Tbl_Sale WHERE SaleID = @SaleID";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            var item = connection.Query<Tbl_Sale>(query, new { SaleID = 1 }).FirstOrDefault();

            if (item == null)
            {
                Console.WriteLine("Sale record not found.");
                return;
            }

            Console.WriteLine($"SaleID: {item.SaleID}, ProductID: {item.ProductID}, Price: {item.Price}, Quantity: {item.Quantity}, Date: {item.SaleDate}");
        }

        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_Sale]
                     SET [ProductID] = @ProductID,
                         [Price] = @Price,
                         [Quantity] = @Quantity,
                         [SaleDate] = @SaleDate
                     WHERE [SaleID] = @SaleID";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new
            {
                SaleID = 1,
                ProductID = 1,
                Price = 1200,
                Quantity = 5,
                SaleDate = DateTime.Now
            });

            string message = result > 0 ? "Sale record updated successfully." : "Failed to update sale record.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            string query = "DELETE FROM [dbo].[Tbl_Sale] WHERE [SaleID] = @SaleID";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new { SaleID = 1 });

            string message = result > 0 ? "Sale record deleted successfully." : "Failed to delete sale record.";
            Console.WriteLine(message);
        }
    }

    public class Tbl_Sale
    {
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
