using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB5.ConsoleApp.DapperSample.DapperSample
{
    public class DapperService
    {
            private string connectionString = "Data Source = MSI; Initial Catalog = Batch5MiniPOS; User ID = sa; Password = sasa@123; Trust Server Certificate = true;";

            public void Create()
            {
                string query = @"INSERT INTO [dbo].[Tbl_Product]
           ([Name]
           ,[Price])
            VALUES
           (@Name,
           @Price)";
                using IDbConnection connection = new SqlConnection(connectionString);
                connection.Open(); //connect 

                int result = connection.Execute(query, new { Name = "Strawberry", Price = 500 });

                string message = result > 0 ? "Product created successfully." : "Failed to create product.";
                Console.WriteLine(message);
            }

            public void Read()
            {
                string query = "Select * from Tbl_Product";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                List<Tbl_Product> lst = connection.Query<Tbl_Product>(query).ToList();

                foreach (Tbl_Product item in lst)
                {
                    Console.WriteLine(item.ID); // item.Name so yin item htl ka (field) ko htoke hmr
                    Console.WriteLine(item.Price);
                    Console.WriteLine(item.Name);
                }

                /*SqlCommand cmd = new SqlCommand(query, connection);
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
                }*/
            }

            public void Edit()
            {
                string query = "Select * from Tbl_Product where ID = @ID;";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                var item = connection.Query<Tbl_Product>(query, new
                {
                    ID = 0
                }).FirstOrDefault();

                if (item == null)
                {
                    Console.WriteLine("Product not found");
                    return;
                }
                Console.WriteLine(item.ID); 
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Name);


        }


            public void Update()
            {
                string query = @"UPDATE [dbo].[Tbl_Product]
                     SET [Name] = @Name,
                         [Price] = @Price
                     WHERE [Id] = @Id";

                using IDbConnection connection = new SqlConnection(connectionString);
                
                connection.Open();
                int result = connection.Execute(query, new
                    {
                        ID = 1,
                        Name = "Banana",
                        Price = 1000
                    });
                    
                connection.Close();
                
                string message = result > 0 ? "Product updated successfully." : "Failed to update product.";
                Console.WriteLine(message);
                
            }

            public void Delete()
            {
                string query = "DELETE FROM [dbo].[Tbl_Product] WHERE [Id] = @Id";

                using IDbConnection connection = new SqlConnection(connectionString);
                connection.Open();

                int result = connection.Execute(query, new { Id = 1 });

                string message = result > 0 ? "Product deleted successfully." : "Failed to delete product.";
                Console.WriteLine(message);
            }
    }

    public class Tbl_Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}


