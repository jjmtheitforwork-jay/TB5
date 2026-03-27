using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB5.AdoDotNetSample
{
    //CRUD - Create, Read, Update, Delete
    public class AdoDotNetService
    {
        //field >> getter setter ma pr tae kg ty ka field
        private string connectionString = "Data Source = MSI; Initial Catalog = Batch5MiniPOS; User ID = sa; Password = sasa@123; Trust Server Certificate = true;";

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Product]
           ([Name]
           ,[Price])
            VALUES
           (@Name,
           @Price)";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open(); //connect 

            SqlCommand cmd = new SqlCommand(query, connection); // d connection ko thone pee query ta khu command pay tr
            cmd.Parameters.AddWithValue("@Name", "Strawberries");
            cmd.Parameters.AddWithValue("@Price", 500);

            int result = cmd.ExecuteNonQuery(); // run kine tr

            connection.Close(); // disconnect

            string message = result > 0 ? "Product created successfully." : "Failed to create product.";
            Console.WriteLine(message);
        }

        public void Read()
        {
            string query = "Select * from Tbl_Product";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);

            connection.Close();

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["Id"]);
                string name = row["Name"].ToString();
                decimal price = Convert.ToDecimal(row["Price"]);

                Console.WriteLine($"Id: {id}, Name: {name}, Price: {price}");
            }
        }

        public void Edit()
        {
            string query = "Select * from Tbl_Product where ID = @ID;";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID", 1);

            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);

            connection.Close();


            if(dt.Rows.Count== 0)
            {
                Console.WriteLine("ID not found");
                return;
            }

            DataRow row = dt.Rows[0];
            int id = Convert.ToInt32(row["Id"]);
            string name = row["Name"].ToString();
            decimal price = Convert.ToDecimal(row["Price"]);

            Console.WriteLine($"Id: {id}, Name: {name}, Price: {price}");
        }
        

        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_Product]
                     SET [Name] = @Name,
                         [Price] = @Price
                     WHERE [Id] = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", 8);
                cmd.Parameters.AddWithValue("@Name", "Strawberries");
                cmd.Parameters.AddWithValue("@Price", 5000);

                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Product updated successfully." : "Failed to update product.";
                Console.WriteLine(message);
            }
        }

        public void Delete()
        {
            string query = @"DELETE FROM [dbo].[Tbl_Product]
                     WHERE [Id] = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", 10);


                int result = cmd.ExecuteNonQuery();
                string message = result > 0 ? "Product deleted successfully." : "Failed to delete product.";
                Console.WriteLine(message);
            }
        }
    }
}    


   
    public class Tbl_Product
     {
        //properties getter setter pr tae kg ty ka properties
            public int ID { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
     }

    public class Tbl_Sale
     {
            public int SaleID { get; set; }
            public int ProductID { get; set; }
            public decimal Price { get; set; }
            public int? Quantity { get; set; }
            public DateTime SaleDate { get; set; }
     }
    

