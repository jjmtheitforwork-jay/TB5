namespace TB5.WebApi.Models
{
    public class ProductCreateRequest
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; } 
    }

    public class ProductCreateResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
        public int ID { get; set; }
    }
}
