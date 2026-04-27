// Models/Instructor.cs
namespace UniversityManagement.Models;

public class Instructor
{
    public int InstructorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;

    // FK — many Instructors belong to one Department
    public int DepartmentId { get; set; }
    public Department? Department_ { get; set; }

    // Navigation property — one Instructor teaches many Courses
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}