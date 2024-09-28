using Microsoft.AspNetCore.Mvc;
using eticaretwebapi.Data;
using Microsoft.EntityFrameworkCore;
using eticaret_uygulama.Models;
namespace eticaretwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        [HttpGet("id")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<Products>> DeleteProduct(int id)
        {
            var result = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();

            }
            return result;
        }
        [HttpPut("id")]
        public async Task<ActionResult<Products>> UpdateProduct(Products product, int id)
        {
            var result = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (result != null)
            {
                result.ProductName = product.ProductName;
                result.Productdescription = product.Productdescription;
                result.ProductPrice = product.ProductPrice;
                result.ProductCode = product.ProductCode;
                result.ProductPicture = product.ProductPicture;
                await _context.SaveChangesAsync();
            }
            return result;
        }
        [HttpPost]
        public async Task<ActionResult> PostProduct(Products product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}