using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartRetailAPI.Data;
using SmartRetailAPI.Models;

namespace SmartRetailAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Products.ToList());

        [HttpPost]
        public IActionResult Post(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            var data = _context.Products.Find(id);
            if (data == null) return NotFound();
            data.Name = product.Name;
            data.Price = product.Price;
            _context.SaveChanges();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.Products.Find(id);
            if (data == null) return NotFound();
            _context.Products.Remove(data);
            _context.SaveChanges();
            return Ok();
        }
    }
}