using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB5.ConsoleApp.EFCoreSample.AppDbContextModels;

namespace TB5.ConsoleApp.EFCoreSample.EFCoreSample
{
    public class EFCoreService
    {
        private AppDbContext db = new AppDbContext();

        public void Read()
        {
            
            List<TblProduct> lst = db.TblProducts.ToList();

            foreach (TblProduct item in lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Name);
            }

            TblProduct Product = new TblProduct()
            {
                Name = "Test",
                Price = 1000.ToString(),


            };
        }

        public void Edit()
        {
            
            TblProduct? itemproduct = db.TblProducts.Where(x => x.Id == 1).FirstOrDefault();
            if (itemproduct == null)
            {
                Console.WriteLine("Product not found");
                return;
            }
            itemproduct.Price = 10000.ToString();
            db.SaveChanges();
            Console.WriteLine(itemproduct.Id);
            Console.WriteLine(itemproduct.Price);
            Console.WriteLine(itemproduct.Name);

        }

        public void Create()
        {
            TblProduct Product = new TblProduct()
            {
                Name = "Test",
                Price = "1000"
            };
            db.TblProducts.Add(Product);
            int result = db.SaveChanges(); // d kya hma tagl execute lote tr
            string message = result > 0 ? "Product created successfully." : "Failed to create product.";
            Console.WriteLine(message);
        }

        public void Update()
        {
            TblProduct? itemproduct = db.TblProducts.Where(x => x.Id == 1).FirstOrDefault();
            if (itemproduct == null)
            {
                Console.WriteLine("Product not found");
                return;
            }
            itemproduct.Price = "10000";
            int result = db.SaveChanges();
            string message = result > 0 ? "Product created successfully." : "Failed to create product.";
            Console.WriteLine(message);

        }

        public void Delete()
        {
            TblProduct? itemproduct = db.TblProducts.FirstOrDefault(x => x.Id == 1);
            if (itemproduct == null)
            {
                Console.WriteLine("Product not found");
                return;
            }
            db.TblProducts.Remove(itemproduct);
            int result = db.SaveChanges();
            string message = result > 0 ? "Product deleted successfully." : "Failed to delete product.";
            Console.WriteLine(message);
        }
    }
}
