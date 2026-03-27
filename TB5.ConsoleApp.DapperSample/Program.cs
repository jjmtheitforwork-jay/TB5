// See https://aka.ms/new-console-template for more information
using TB5.ConsoleApp.DapperSample.DapperSample;

Console.WriteLine("Hello, World!");

DapperService service = new DapperService();
service.Read();
service.Create();
service.Delete();

SaleDapperService saleService = new SaleDapperService();
saleService.Create();
saleService.Read();
saleService.Edit();

ProductCategoryDapperService categoryService = new ProductCategoryDapperService();
categoryService.Create();
categoryService.Read();
categoryService.Update();
categoryService.Delete();