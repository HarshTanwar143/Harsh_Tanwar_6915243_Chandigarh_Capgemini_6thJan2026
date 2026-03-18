using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
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

        public IActionResult Index()
        {
            // Protect page — must be logged in
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login", "Account");

            return View(products);
        }
    }
}