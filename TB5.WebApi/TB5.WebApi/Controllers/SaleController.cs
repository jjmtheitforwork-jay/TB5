using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TB_.WebApi.Database.AppDbContextModels;
using TB5.WebApi.Models;

namespace TB5.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly AppDbContext db = new AppDbContext();

        // GET: api/Sale
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = db.TblSales.ToList();
            return Ok(list);
        }

        // GET: api/Sale/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = db.TblSales.FirstOrDefault(x => x.SaleId == id);

            if (item == null)
                return NotFound("Sale record not found");

            return Ok(item);
        }

        // POST: api/Sale
        [HttpPost]
        public IActionResult Create([FromBody] SaleCreateRequest request)
        {
            TblSale sale = new TblSale
            {
                ProductId = request.ProductId,
                Price = request.Price,
                Quantity = request.Quantity,
                SaleDate = DateTime.Now
            };
            db.TblSales.Add(sale);
            int result = db.SaveChanges();

            bool isSuccess = result > 0;
            SaleCreateResponse response = new SaleCreateResponse
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Sale record created successfully" : "Failed to create sale record",
                ID = sale.SaleId
            };
            return result > 0 ? Ok(response) : BadRequest(response);
        }

        // PUT: api/Sale/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SaleModifyRequest request)
        {
            var item = db.TblSales.FirstOrDefault(x => x.SaleId == id);

            if (item == null)
            {
                SaleModifyResponse notFoundResponse = new SaleModifyResponse
                {
                    IsSuccess = false,
                    Message = "Sale record not found",
                    ID = id
                };
                return NotFound(notFoundResponse);
            }

            // Update fields
            item.ProductId = request.ProductId;
            item.Price = request.Price;
            item.Quantity = request.Quantity;
            item.SaleDate = DateTime.Now;

            int result = db.SaveChanges();

            bool isSuccess = result > 0;
            SaleModifyResponse response = new SaleModifyResponse
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Sale record updated successfully" : "Failed to update sale record",
                ID = item.SaleId
            };

            return isSuccess ? Ok(response) : BadRequest(response);
        }

        // DELETE: api/Sale/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = db.TblSales.FirstOrDefault(x => x.SaleId == id);

            if (item == null)
                return NotFound("Sale record not found");

            db.TblSales.Remove(item);
            int result = db.SaveChanges();

            if (result > 0)
                return Ok("Sale record deleted successfully");

            return BadRequest("Failed to delete sale record");
        }
    }
}
