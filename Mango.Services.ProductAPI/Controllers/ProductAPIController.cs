using Mango.Services.ProductAPI.Data;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProductAPIController(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> product = _db.Products.ToList();

            if (product.Count() > 0)
            {
                return Ok(product);
            }
            
            return NotFound();
        }
    }
}
