// Models/Course.cs
namespace UniversityManagement.Models;

public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Credits { get; set; }

    // FK — many Courses belong to one Instructor
    public int InstructorId { get; set; }
    public Instructor? Instructor { get; set; }

    // Navigation property — one Course has many Enrollments
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}