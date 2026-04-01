using System.ComponentModel.DataAnnotations;

namespace LearningPlatformAPI.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}