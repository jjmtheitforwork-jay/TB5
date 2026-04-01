using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB5.AdoDotNetSample
{
    public class ProductCategoryAdoDotNetService
    {
        private string connectionString = "Data Source = MSI; Initial Catalog = Batch5MiniPOS; User ID = sa; Password = sasa@123; Trust Server Certificate = true;";

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_ProductCategory]
           ([ProductCategoryName])
            VALUES
           (@ProductCategoryName)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductCategoryName", "New Category");

                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Product Category created successfully." : "Failed to create product category.";
                Console.WriteLine(message);
            }
        }

        public void Read()
        {
            string query = "SELECT * FROM Tbl_ProductCategory";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["ProductCategoryID"]);
                    string name = row["ProductCategoryName"].ToString();

                    Console.WriteLine($"ProductCategoryID: {id}, ProductCategoryName: {name}");
                }
            }
        }

        public void Edit()
        {
            string query = "SELECT * FROM Tbl_ProductCategory WHERE ProductCategoryID = @ProductCategoryID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductCategoryID", 1);

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("Product Category not found.");
                    return;
                }

                DataRow row = dt.Rows[0];
                int id = Convert.ToInt32(row["ProductCategoryID"]);
                string name = row["ProductCategoryName"].ToString();

                Console.WriteLine($"ProductCategoryID: {id}, ProductCategoryName: {name}");
            }
        }

        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_ProductCategory]
                     SET [ProductCategoryName] = @ProductCategoryName
                     WHERE [ProductCategoryID] = @ProductCategoryID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductCategoryID", 1);
                cmd.Parameters.AddWithValue("@ProductCategoryName", "Updated Category Name");

                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Product Category updated successfully." : "Failed to update product category.";
                Console.WriteLine(message);
            }
        }

        public void Delete()
        {
            string query = @"DELETE FROM [dbo].[Tbl_ProductCategory] WHERE [ProductCategoryID] = @ProductCategoryID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductCategoryID", 1);

                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Product Category deleted successfully." : "Failed to delete product category.";
                Console.WriteLine(message);
            }
        }
    }
}
