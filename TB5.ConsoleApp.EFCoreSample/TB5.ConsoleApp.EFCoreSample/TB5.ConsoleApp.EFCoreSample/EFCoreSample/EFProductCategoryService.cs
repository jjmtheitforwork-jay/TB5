using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB5.ConsoleApp.EFCoreSample.AppDbContextModels;

namespace TB5.ConsoleApp.EFCoreSample.EFCoreSample
{
    public class EFProductCategoryService
    {
        private AppDbContext db = new AppDbContext();

        public void Read()
        {
            List<TblProductCategory> lst = db.TblProductCategories.ToList();

            foreach (TblProductCategory item in lst)
            {
                Console.WriteLine(item.ProductCategoryId);
                Console.WriteLine(item.ProductCategoryName);
            }
        }

        public void Edit()
        {
            TblProductCategory? itemcategory = db.TblProductCategories.Where(x => x.ProductCategoryId == 1).FirstOrDefault();
            if (itemcategory == null)
            {
                Console.WriteLine("Category not found");
                return;
            }
            itemcategory.ProductCategoryName = "Updated Category Name";
            db.SaveChanges();
            Console.WriteLine(itemcategory.ProductCategoryId);
            Console.WriteLine(itemcategory.ProductCategoryName);
        }

        public void Create()
        {
            TblProductCategory category = new TblProductCategory()
            {
                ProductCategoryName = "New Category"
            };
            db.TblProductCategories.Add(category);
            int result = db.SaveChanges();
            string message = result > 0 ? "Category created successfully." : "Failed to create category.";
            Console.WriteLine(message);
        }

        public void Update()
        {
            TblProductCategory? itemcategory = db.TblProductCategories.Where(x => x.ProductCategoryId == 1).FirstOrDefault();
            if (itemcategory == null)
            {
                Console.WriteLine("Category not found");
                return;
            }
            itemcategory.ProductCategoryName = "Updated Category Name";
            int result = db.SaveChanges();
            string message = result > 0 ? "Category updated successfully." : "Failed to update category.";
            Console.WriteLine(message);

        }

        public void Delete()
        {
            TblProductCategory? itemcategory = db.TblProductCategories.FirstOrDefault(x => x.ProductCategoryId == 1);
            if (itemcategory == null)
            {
                Console.WriteLine("Category not found");
                return;
            }
            db.TblProductCategories.Remove(itemcategory);
            int result = db.SaveChanges();
            string message = result > 0 ? "Category deleted successfully." : "Failed to delete category.";
            Console.WriteLine(message);
        }
    }
}
