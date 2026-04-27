// Models/BookIndexViewModel.cs
namespace LibraryManagement.Models;

public class BookIndexViewModel
{
    public IEnumerable<Book> Books { get; set; } = new List<Book>();
    public IReadOnlyList<OperationLog> OperationLogs { get; set; } = new List<OperationLog>();
    public Book NewBook { get; set; } = new();
}