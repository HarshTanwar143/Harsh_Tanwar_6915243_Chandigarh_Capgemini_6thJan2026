using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Services;
using System.Diagnostics;

namespace StudentPortal.Controllers;

public class StudentsController : Controller
{
    private readonly IRequestLoggingService _loggingService;

    // In-memory student list (acts as a fake DB)
    private static List<Student> _students = new()
    {
        new() { Id = 1, Name = "Alice Johnson", Email = "alice@example.com", Course = "Computer Science" },
        new() { Id = 2, Name = "Bob Smith",     Email = "bob@example.com",   Course = "Mathematics" },
        new() { Id = 3, Name = "Carol White",   Email = "carol@example.com", Course = "Physics" },
    };
    private static int _nextId = 4;

    public StudentsController(IRequestLoggingService loggingService)
    {
        _loggingService = loggingService;
    }

    // GET /Students/Index
    public IActionResult Index()
    {
        var viewModel = new StudentIndexViewModel
        {
            Students = _students,
            RequestLogs = _loggingService.GetLogs(),
            NewStudent = new Student()
        };
        return View(viewModel);
    }

    // POST /Students/Create
    [HttpPost]
    public IActionResult Create(Student student)
    {
        var sw = Stopwatch.StartNew();

        student.Id = _nextId++;
        _students.Add(student);

        sw.Stop();
        _loggingService.Log("/Students/Create", sw.ElapsedMilliseconds, "CREATE");

        return RedirectToAction("Index");
    }

    // POST /Students/Update
    [HttpPost]
    public IActionResult Update(Student student)
    {
        var sw = Stopwatch.StartNew();

        var existing = _students.FirstOrDefault(s => s.Id == student.Id);
        if (existing != null)
        {
            existing.Name = student.Name;
            existing.Email = student.Email;
            existing.Course = student.Course;
        }

        sw.Stop();
        _loggingService.Log($"/Students/Update/{student.Id}", sw.ElapsedMilliseconds, "UPDATE");

        return RedirectToAction("Index");
    }

    // POST /Students/Delete
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var sw = Stopwatch.StartNew();

        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student != null)
            _students.Remove(student);

        sw.Stop();
        _loggingService.Log($"/Students/Delete/{id}", sw.ElapsedMilliseconds, "DELETE");

        return RedirectToAction("Index");
    }
}