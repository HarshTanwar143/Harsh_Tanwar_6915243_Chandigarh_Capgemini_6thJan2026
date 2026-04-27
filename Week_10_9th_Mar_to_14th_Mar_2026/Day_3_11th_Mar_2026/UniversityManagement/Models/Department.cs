// Models/Department.cs
namespace UniversityManagement.Models;

public class Department
{
    public int DepartmentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Budget { get; set; }

    // Navigation property — one Department has many Instructors
    public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}