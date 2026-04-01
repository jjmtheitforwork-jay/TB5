using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TB_.WebApi.Database.AppDbContextModels;
using TB5.WebApi.Models;

namespace TB5.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly AppDbContext db = new AppDbContext();

        // GET: api/ProductCategory
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = db.TblProductCategories.ToList();
            return Ok(list);
        }

        // GET: api/ProductCategory/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = db.TblProductCategories.FirstOrDefault(x => x.ProductCategoryId == id);

            if (item == null)
                return NotFound("Product category not found");

            return Ok(item);
        }

        // POST: api/ProductCategory
        [HttpPost]
        public IActionResult Create([FromBody] ProductCategoryCreateRequest request)
        {
            TblProductCategory category = new TblProductCategory
            {
                ProductCategoryName = request.ProductCategoryName
            };
            db.TblProductCategories.Add(category);
            int result = db.SaveChanges();

            bool isSuccess = result > 0;
            ProductCategoryCreateResponse response = new ProductCategoryCreateResponse
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Product category created successfully" : "Failed to create product category",
                ID = category.ProductCategoryId
            };
            return result > 0 ? Ok(response) : BadRequest(response);
        }

        // PUT: api/ProductCategory/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductCategoryModifyRequest request)
        {
            var item = db.TblProductCategories.FirstOrDefault(x => x.ProductCategoryId == id);

            if (item == null)
            {
                ProductCategoryModifyResponse notFoundResponse = new ProductCategoryModifyResponse
                {
                    IsSuccess = false,
                    Message = "Product category not found",
                    ID = id
                };
                return NotFound(notFoundResponse);
            }

            // Update fields
            item.ProductCategoryName = request.ProductCategoryName;

            int result = db.SaveChanges();

            bool isSuccess = result > 0;
            ProductCategoryModifyResponse response = new ProductCategoryModifyResponse
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Product category updated successfully" : "Failed to update product category",
                ID = item.ProductCategoryId
            };

            return isSuccess ? Ok(response) : BadRequest(response);
        }

        // DELETE: api/ProductCategory/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = db.TblProductCategories.FirstOrDefault(x => x.ProductCategoryId == id);

            if (item == null)
                return NotFound("Product category not found");

            db.TblProductCategories.Remove(item);
            int result = db.SaveChanges();

            if (result > 0)
                return Ok("Product category deleted successfully");

            return BadRequest("Failed to delete product category");
        }
    }
}
