// See https://aka.ms/new-console-template for more information
using TB5.ConsoleApp.EFCoreSample.AppDbContextModels;
using TB5.ConsoleApp.EFCoreSample.EFCoreSample;

Console.WriteLine("Hello, World!");
EFCoreService categoryService = new EFCoreService();
categoryService.Create();
categoryService.Read();
categoryService.Update();
categoryService.Delete();
Console.ReadLine();

/*
//Read
AppDbContext db = new AppDbContext();
List<TblProduct> lst = db.TblProducts.ToList();

foreach (TblProduct item in lst)
{
    Console.WriteLine(item.Id); 
    Console.WriteLine(item.Price);
    Console.WriteLine(item.Name);
}

//create
TblProduct Product = new TblProduct()
{
    Name = "Test",
    Price = 1000.ToString(),


};
int result = db.SaveChanges(); // d kya hma tagl execute lote tr
string message = result > 0 ? "Product created successfully." : "Failed to create product.";
Console.WriteLine(message);


//Edit
TblProduct? itemproduct = db.TblProducts.Where(x => x.Id == 1) .FirstOrDefault();
if (itemproduct == null)
{
    Console.WriteLine("Product not found");
    return;
}
itemproduct.Price = 10000.ToString();
db.SaveChanges();

//delete
db.TblProducts.Remove(itemproduct);
db.SaveChanges();*/