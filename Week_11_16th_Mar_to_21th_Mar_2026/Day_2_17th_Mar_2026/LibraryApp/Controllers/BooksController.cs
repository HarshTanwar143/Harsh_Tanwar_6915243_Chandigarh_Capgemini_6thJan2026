using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {
        // ✅ Inject DbContext via constructor
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Books/Index
        public IActionResult Index()
        {
            ViewBag.WelcomeMessage = "Welcome to the Library Management System!";
            ViewData["TotalBooks"] = _context.Books.Count();

            // ✅ Fetch books from DB instead of in-memory list
            var viewModels = _context.Books.Select(b => new BookViewModel
            {
                Book = b,
                IsAvailable = true,
                BorrowerName = "N/A"
            }).ToList();

            return View(viewModels);
        }

        // GET: /Books/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Books/Create
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                // ✅ Save to database
                _context.Books.Add(book);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Book added successfully!";
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}