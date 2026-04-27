// Controllers/EnrollmentsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Data;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers;

public class EnrollmentsController : Controller
{
    private readonly UniversityDbContext _context;

    public EnrollmentsController(UniversityDbContext context)
    {
        _context = context;
    }

    // GET /Enrollments/Enroll/3  (3 = StudentId)
    public async Task<IActionResult> Enroll(int id)
    {
        var student = await _context.Students
            .Include(s => s.Enrollments)
            .FirstOrDefaultAsync(s => s.StudentId == id);

        if (student == null)
            return NotFound();

        // Get only courses the student is NOT already enrolled in
        var enrolledCourseIds = student.Enrollments.Select(e => e.CourseId).ToList();

        var availableCourses = await _context.Courses
            .Include(c => c.Instructor)
            .Where(c => !enrolledCourseIds.Contains(c.CourseId))
            .ToListAsync();

        ViewBag.Student = student;
        ViewBag.AvailableCourses = availableCourses;

        return View();
    }

    // POST /Enrollments/Enroll
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Enroll(int StudentId, int CourseId, string Grade)
    {
        // Check if already enrolled
        var exists = await _context.Enrollments
            .AnyAsync(e => e.StudentId == StudentId && e.CourseId == CourseId);

        if (!exists)
        {
            var enrollment = new Enrollment
            {
                StudentId = StudentId,
                CourseId = CourseId,
                Grade = Grade
            };
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index", "Students");
    }

    // POST /Enrollments/Unenroll
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Unenroll(int enrollmentId)
    {
        var enrollment = await _context.Enrollments.FindAsync(enrollmentId);
        if (enrollment != null)
        {
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index", "Students");
    }
}