namespace TB5.WebApi.Models
{
    public class ProductCategoryCreateRequest
    {
        public string ProductCategoryName { get; set; } = null!;
    }

    public class ProductCategoryCreateResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int ID { get; set; }
    }
}
