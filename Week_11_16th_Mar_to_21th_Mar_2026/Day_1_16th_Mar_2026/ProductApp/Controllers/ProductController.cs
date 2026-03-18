using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop",   Price = 75000 },
            new Product { Id = 2, Name = "Mouse",    Price = 999   },
            new Product { Id = 3, Name = "Keyboard", Price = 1500  },
            new Product { Id = 4, Name = "Monitor",  Price = 18000 },
        };

        // GET: /Product/Index
        public IActionResult Index()
        {
            return View(products);
        }

        // GET: /Product/Crash  ← to TEST exception filter
        public IActionResult Crash()
        {
            throw new Exception("💥 Test exception to verify the exception filter!");
        }
    }
}