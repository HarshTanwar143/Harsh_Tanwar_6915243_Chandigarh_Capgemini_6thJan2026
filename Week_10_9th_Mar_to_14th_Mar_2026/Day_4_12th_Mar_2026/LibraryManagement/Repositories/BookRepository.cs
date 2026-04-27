// Repositories/BookRepository.cs
using LibraryManagement.Models;

namespace LibraryManagement.Repositories;

/// <summary>
/// Concrete implementation of IBookRepository.
/// Registered as AddScoped in DI — new instance per HTTP request.
/// Static list simulates a database.
/// </summary>
public class BookRepository : IBookRepository
{
    private static List<Book> _books = new()
    {
        new Book { Id = 1, Title = "Clean Code",               Author = "Robert C. Martin", ISBN = "978-0132350884", Year = 2008, IsAvailable = true  },
        new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt",      ISBN = "978-0201616224", Year = 1999, IsAvailable = true  },
        new Book { Id = 3, Title = "Design Patterns",          Author = "Gang of Four",     ISBN = "978-0201633610", Year = 1994, IsAvailable = false },
        new Book { Id = 4, Title = "Domain-Driven Design",     Author = "Eric Evans",       ISBN = "978-0321125217", Year = 2003, IsAvailable = true  },
    };
    private static int _nextId = 5;

    public IEnumerable<Book> GetAll() => _books;

    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public void Add(Book book)
    {
        book.Id = _nextId++;
        _books.Add(book);
    }

    public void Update(Book book)
    {
        var existing = _books.FirstOrDefault(b => b.Id == book.Id);
        if (existing != null)
        {
            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.ISBN = book.ISBN;
            existing.Year = book.Year;
            existing.IsAvailable = book.IsAvailable;
        }
    }

    public void Delete(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book != null)
            _books.Remove(book);
    }
}