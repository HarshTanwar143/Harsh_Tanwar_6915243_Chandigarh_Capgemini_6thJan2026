// Controllers/StudentsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Data;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers;

public class StudentsController : Controller
{
    private readonly UniversityDbContext _context;

    // DbContext injected via Constructor DI
    public StudentsController(UniversityDbContext context)
    {
        _context = context;
    }

    // GET /Students/Index
    // Shows all students with their enrolled courses and grades
    public async Task<IActionResult> Index()
    {
        var students = await _context.Students
            .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
            .ToListAsync();

        return View(students);
    }

    // GET /Students/Details/1
    public async Task<IActionResult> Details(int id)
    {
        var student = await _context.Students
            .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(s => s.StudentId == id);

        if (student == null)
            return NotFound();

        return View(student);
    }

    // GET /Students/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST /Students/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        if (ModelState.IsValid)
        {
            student.EnrollmentDate = DateTime.Now;
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(student);
    }

    // GET /Students/Edit/1
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
            return NotFound();
        return View(student);
    }

    // POST /Students/Edit/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Student student)
    {
        if (id != student.StudentId)
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(student);
    }

    // GET /Students/Delete/1
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _context.Students
            .Include(s => s.Enrollments)
            .FirstOrDefaultAsync(s => s.StudentId == id);

        if (student == null)
            return NotFound();

        return View(student);
    }

    // POST /Students/Delete/1
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}