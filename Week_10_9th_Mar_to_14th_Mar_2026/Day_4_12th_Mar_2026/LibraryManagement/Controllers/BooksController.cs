// Controllers/BooksController.cs
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.Services;
using System.Diagnostics;

namespace LibraryManagement.Controllers;

/// <summary>
/// Handles all /Books/* routes.
/// IBookRepository and IOperationLogService both injected via Constructor DI.
/// </summary>
public class BooksController : Controller
{
    private readonly IBookRepository _bookRepository;
    private readonly IOperationLogService _logService;

    // Constructor DI — both services provided by DI container
    public BooksController(
        IBookRepository bookRepository,
        IOperationLogService logService)
    {
        _bookRepository = bookRepository;
        _logService = logService;
    }

    // GET /Books/Index
    public IActionResult Index()
    {
        var viewModel = new BookIndexViewModel
        {
            Books = _bookRepository.GetAll(),
            OperationLogs = _logService.GetLogs(),
            NewBook = new Book()
        };
        return View(viewModel);
    }

    // GET /Books/Details/1
    public IActionResult Details(int id)
    {
        var book = _bookRepository.GetById(id);
        if (book is null)
            return NotFound($"Book with ID {id} was not found.");
        return View(book);
    }

    // POST /Books/Create
    [HttpPost]
    public IActionResult Create(Book book)
    {
        var sw = Stopwatch.StartNew();

        _bookRepository.Add(book);

        sw.Stop();
        _logService.Log(
            "CREATE",
            $"Added book: '{book.Title}' by {book.Author}",
            sw.ElapsedMilliseconds);

        return RedirectToAction("Index");
    }

    // POST /Books/Update
    [HttpPost]
    public IActionResult Update(Book book)
    {
        var sw = Stopwatch.StartNew();

        _bookRepository.Update(book);

        sw.Stop();
        _logService.Log(
            "UPDATE",
            $"Updated book ID {book.Id}: '{book.Title}'",
            sw.ElapsedMilliseconds);

        return RedirectToAction("Index");
    }

    // POST /Books/Delete
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var sw = Stopwatch.StartNew();

        var book = _bookRepository.GetById(id);
        var title = book?.Title ?? "Unknown";
        _bookRepository.Delete(id);

        sw.Stop();
        _logService.Log(
            "DELETE",
            $"Deleted book ID {id}: '{title}'",
            sw.ElapsedMilliseconds);

        return RedirectToAction("Index");
    }
}