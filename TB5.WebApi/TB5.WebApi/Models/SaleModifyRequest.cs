namespace TB5.WebApi.Models
{
    public class SaleModifyRequest
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class SaleModifyResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int ID { get; set; }
    }
}
