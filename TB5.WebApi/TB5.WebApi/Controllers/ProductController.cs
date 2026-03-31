using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TB_.WebApi.Database.AppDbContextModels;
using TB5.WebApi.Models;

namespace TB5.WebApi.Controllers
{
    // api/Product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext db = new AppDbContext();

        
        // ✅ GET: api/Product
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = db.TblProducts.ToList();
            return Ok(list); // returns JSON
        }

        // ✅ GET: api/Product/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = db.TblProducts.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound("Product not found");

            return Ok(item);
        }

        // ✅ POST: api/Product
        [HttpPost]
        public IActionResult Create([FromBody] ProductCreateRequest request)
        {
            TblProduct product = new TblProduct
            {
                CreatedDateTime = DateTime.Now,
                IsDeleted = false,
                Name = request.Name,
                Price = request.Price,
            };
            db.TblProducts.Add(product);
            int result = db.SaveChanges();

            bool isSuccess = result > 0;
            ProductCreateResponse response = new ProductCreateResponse
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Product created successfully" : "Failed to create product",
                ID = product.Id
            };
            return result > 0 ? Ok(response) : BadRequest(response);

            /*if (result > 0)
                return Ok(new { message = "Product created successfully", data = product });

            return BadRequest("Failed to create product");*/
        }

        // ✅ PUT: api/Product/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductModifyRequest request)
        {
            TblProduct? item = db.TblProducts.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (item == null)
            {
                ProductModifyResponse notFoundResponse = new ProductModifyResponse
                {
                    IsSuccess = false,
                    Message = "Product not found",
                    ID = id
                };
                return NotFound(notFoundResponse);
            }

            // Update fields
            item.Name = request.Name;
            item.Price = request.Price;
            item.ModifyDateTime = DateTime.Now;

            int result = db.SaveChanges();

            bool isSuccess = result > 0;
            ProductModifyResponse response = new ProductModifyResponse
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Product updated successfully" : "Failed to update product",
                ID = item.Id
            };

            return isSuccess ? Ok(response) : BadRequest(response);
        }

        // ✅ DELETE: api/Product/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = db.TblProducts.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound("Product not found");

            db.TblProducts.Remove(item);
            int result = db.SaveChanges();

            if (result > 0)
                return Ok("Product deleted successfully");

            return BadRequest("Failed to delete product");
        }
    }
}
