namespace TB5.WebApi.Models
{
    public class SaleCreateRequest
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class SaleCreateResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int ID { get; set; }
    }
}
