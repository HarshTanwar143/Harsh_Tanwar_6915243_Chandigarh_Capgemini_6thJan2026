// Models/Enrollment.cs
namespace UniversityManagement.Models;

public class Enrollment
{
    public int EnrollmentId { get; set; }

    // FK → Student
    public int StudentId { get; set; }
    public Student? Student { get; set; }

    // FK → Course
    public int CourseId { get; set; }
    public Course? Course { get; set; }

    public string Grade { get; set; } = string.Empty;
}