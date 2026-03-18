using Microsoft.AspNetCore.Mvc;
using StudentApp.Data;
using StudentApp.Models;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;

        // Inject the database context
        public StudentController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /Student/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Student/Register
        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(student);   // Add to database
                _db.SaveChanges();           // Save to database

                TempData["SuccessMessage"] = "Student registered successfully!";

                return RedirectToAction("Details", new { id = student.Id });
            }

            return View(student);
        }

        // GET: /Student/Details/1
        public IActionResult Details(int id)
        {
            var student = _db.Students.FirstOrDefault(s => s.Id == id); // Fetch from DB
            if (student == null) return NotFound();
            return View(student);
        }
    }
}