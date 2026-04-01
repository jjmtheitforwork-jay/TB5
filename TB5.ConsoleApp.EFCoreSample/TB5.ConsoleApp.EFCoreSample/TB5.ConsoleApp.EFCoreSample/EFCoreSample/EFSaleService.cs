using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB5.ConsoleApp.EFCoreSample.AppDbContextModels;

namespace TB5.ConsoleApp.EFCoreSample.EFCoreSample
{
    public class EFSaleService
    {
        private AppDbContext db = new AppDbContext();

        public void Read()
        {
            List<TblSale> lst = db.TblSales.ToList();

            foreach (TblSale item in lst)
            {
                Console.WriteLine(item.SaleId);
                Console.WriteLine(item.ProductId);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Quantity);
                Console.WriteLine(item.SaleDate);
            }
        }

        public void Edit()
        {
            TblSale? itemsale = db.TblSales.Where(x => x.SaleId == 1).FirstOrDefault();
            if (itemsale == null)
            {
                Console.WriteLine("Sale not found");
                return;
            }
            itemsale.Price = 1000;
            db.SaveChanges();
            Console.WriteLine(itemsale.SaleId);
            Console.WriteLine(itemsale.Price);
        }

        public void Create()
        {
            TblSale Sale = new TblSale()
            {
                ProductId = 1,
                Price = 1000,
                Quantity = 10,
                SaleDate = DateTime.Now
            };
            db.TblSales.Add(Sale);
            int result = db.SaveChanges(); 
            string message = result > 0 ? "Sale created successfully." : "Failed to create sale.";
            Console.WriteLine(message);
        }

        public void Update()
        {
            TblSale? itemsale = db.TblSales.Where(x => x.SaleId == 1).FirstOrDefault();
            if (itemsale == null)
            {
                Console.WriteLine("Sale not found");
                return;
            }
            itemsale.Price = 1000;
            int result = db.SaveChanges();
            string message = result > 0 ? "Sale updated successfully." : "Failed to update sale.";
            Console.WriteLine(message);

        }

        public void Delete()
        {
            TblSale? itemsale = db.TblSales.FirstOrDefault(x => x.SaleId == 1);
            if (itemsale == null)
            {
                Console.WriteLine("Sale not found");
                return;
            }
            db.TblSales.Remove(itemsale);
            int result = db.SaveChanges();
            string message = result > 0 ? "Sale deleted successfully." : "Failed to delete sale.";
            Console.WriteLine(message);
        }
    }
}
