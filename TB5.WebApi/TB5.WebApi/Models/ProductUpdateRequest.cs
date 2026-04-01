namespace TB5.WebApi.Models
{
    public class ProductModifyRequest
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }


    public class ProductModifyResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
        public int ID { get; set; }
    }

}
