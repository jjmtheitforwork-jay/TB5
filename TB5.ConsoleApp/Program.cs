// See https://aka.ms/new-console-template for more information


using Microsoft.Data.SqlClient;
using TB5.AdoDotNetSample;


//Console.WriteLine(" Hello world");

/*Console.WriteLine("Enter the student name : ");
string name  = Console.ReadLine();

Console.WriteLine("Enter the age of the student : ");
string age = Console.ReadLine();

Console.WriteLine("Enter the StudentId");
string StudentId     = Console.ReadLine();

Console.WriteLine("Enter the marks");
string Marks = Console.ReadLine();

Student student = new Student();
student.Name = name;
student.Age = Convert.ToInt32 (age);
student.StudentId = StudentId;
student.SetMark(Convert.ToInt32(Marks));
string grade = student.Grade();  
Console.WriteLine("Your result is " + grade);
*/


/*SqlConnection conn = new SqlConnection("Data Source = MSI; Initial Catalog = Batch5MiniPOS; User ID = sa; Password = sasa@123; Trust Server Certificate = true;");
conn.Open();
conn.Close();*/


AdoDotNetService service = new AdoDotNetService();
//service.Delete();
//service.Read();
service.Edit();

SaleAdoDotNetService saleService = new SaleAdoDotNetService();
//saleService.Create();
//saleService.Read();
saleService.Edit();

Console.ReadLine();
