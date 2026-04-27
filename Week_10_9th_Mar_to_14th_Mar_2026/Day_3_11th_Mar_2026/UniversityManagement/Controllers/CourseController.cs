// Controllers/CoursesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Data;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers;

[Route("Courses/[action]/{id?}")]
public class CourseController : Controller
{
    private readonly UniversityDbContext _context;

    public CourseController(UniversityDbContext context)
    {
        _context = context;
    }

    // GET /Courses/Index
    public async Task<IActionResult> Index()
    {
        var courses = await _context.Courses
            .Include(c => c.Instructor)
            .Include(c => c.Enrollments)
            .ToListAsync();

        return View(courses);
    }

    // GET /Courses/Details/1
    public async Task<IActionResult> Details(int id)
    {
        var course = await _context.Courses
            .Include(c => c.Instructor)
            .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student)
            .FirstOrDefaultAsync(c => c.CourseId == id);

        if (course == null)
            return NotFound();

        return View(course);
    }

    // GET /Courses/Create
    public async Task<IActionResult> Create()
    {
        ViewBag.Instructors = await _context.Instructors.ToListAsync();
        return View();
    }

    // POST /Courses/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Course course)
    {
        if (ModelState.IsValid)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        ViewBag.Instructors = await _context.Instructors.ToListAsync();
        return View(course);
    }

    // GET /Courses/Edit/1
    public async Task<IActionResult> Edit(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
            return NotFound();

        ViewBag.Instructors = await _context.Instructors.ToListAsync();
        return View(course);
    }

    // POST /Courses/Edit/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Course course)
    {
        if (id != course.CourseId)
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        ViewBag.Instructors = await _context.Instructors.ToListAsync();
        return View(course);
    }

    // GET /Courses/Delete/1
    public async Task<IActionResult> Delete(int id)
    {
        var course = await _context.Courses
            .Include(c => c.Instructor)
            .FirstOrDefaultAsync(c => c.CourseId == id);

        if (course == null)
            return NotFound();

        return View(course);
    }

    // POST /Courses/Delete/1
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}