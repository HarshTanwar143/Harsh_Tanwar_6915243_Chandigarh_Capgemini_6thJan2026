// ViewModels/StudentWithCoursesViewModel.cs
using UniversityManagement.Models;

namespace UniversityManagement.ViewModels;

public class StudentWithCoursesViewModel
{
    public Student Student { get; set; } = new();
    public IEnumerable<Student> AllStudents { get; set; } = new List<Student>();
}