using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace TB5.AdoDotNetSample
{
    public class SaleAdoDotNetService
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductID", 1);
                cmd.Parameters.AddWithValue("@Price", 1000);
                cmd.Parameters.AddWithValue("@Quantity", 2);
                cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);

                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Sale record created successfully." : "Failed to create sale record.";
                Console.WriteLine(message);
            }
        }

        public void Read()
        {
            string query = "SELECT * FROM Tbl_Sale";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    int saleId = Convert.ToInt32(row["SaleID"]);
                    int productId = Convert.ToInt32(row["ProductID"]);
                    decimal price = Convert.ToDecimal(row["Price"]);
                    int quantity = Convert.ToInt32(row["Quantity"] == DBNull.Value ? 0 : row["Quantity"]);
                    DateTime saleDate = Convert.ToDateTime(row["SaleDate"]);

                    Console.WriteLine($"SaleID: {saleId}, ProductID: {productId}, Price: {price}, Quantity: {quantity}, Date: {saleDate}");
                }
            }
        }

        public void Edit()
        {
            string query = "SELECT * FROM Tbl_Sale WHERE SaleID = @SaleID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SaleID", 1); 

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("Sale record not found.");
                    return;
                }

                DataRow row = dt.Rows[0];
                int saleId = Convert.ToInt32(row["SaleID"]);
                int productId = Convert.ToInt32(row["ProductID"]);
                decimal price = Convert.ToDecimal(row["Price"]);
                int quantity = Convert.ToInt32(row["Quantity"] == DBNull.Value ? 0 : row["Quantity"]);
                DateTime saleDate = Convert.ToDateTime(row["SaleDate"]);

                Console.WriteLine($"SaleID: {saleId}, ProductID: {productId}, Price: {price}, Quantity: {quantity}, Date: {saleDate}");
            }
        }

        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_Sale]
                     SET [ProductID] = @ProductID,
                         [Price] = @Price,
                         [Quantity] = @Quantity,
                         [SaleDate] = @SaleDate
                     WHERE [SaleID] = @SaleID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SaleID", 1); 
                cmd.Parameters.AddWithValue("@ProductID", 1);
                cmd.Parameters.AddWithValue("@Price", 1200);
                cmd.Parameters.AddWithValue("@Quantity", 5);
                cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);

                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Sale record updated successfully." : "Failed to update sale record.";
                Console.WriteLine(message);
            }
        }

        public void Delete()
        {
            string query = @"DELETE FROM [dbo].[Tbl_Sale] WHERE [SaleID] = @SaleID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SaleID", 1);

                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Sale record deleted successfully." : "Failed to delete sale record.";
                Console.WriteLine(message);
            }
        }
    }
}
