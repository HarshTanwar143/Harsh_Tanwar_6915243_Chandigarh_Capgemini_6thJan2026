// Models/Student.cs
namespace UniversityManagement.Models;

public class Student
{
    public int StudentId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }

    // Navigation property — one Student has many Enrollments
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}