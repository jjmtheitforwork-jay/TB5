namespace TB5.WebApi.Models
{
    public class ProductCategoryModifyRequest
    {
        public string ProductCategoryName { get; set; } = null!;
    }

    public class ProductCategoryModifyResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
        public int ID { get; set; }
    }
}
