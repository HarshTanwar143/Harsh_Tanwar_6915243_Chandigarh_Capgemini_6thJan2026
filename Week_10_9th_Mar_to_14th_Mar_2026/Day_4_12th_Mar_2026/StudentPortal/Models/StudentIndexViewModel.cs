// Models/StudentIndexViewModel.cs
using StudentPortal.Services;

namespace StudentPortal.Models;

/// <summary>
/// ViewModel for /Students/Index — carries both student data
/// and request logs to display on a single page.
/// </summary>
public class StudentIndexViewModel
{
    public List<Student> Students { get; set; } = new();
    public IReadOnlyList<RequestLogEntry> RequestLogs { get; set; }
        = new List<RequestLogEntry>();

    public Student NewStudent { get; set; } = new();
}
