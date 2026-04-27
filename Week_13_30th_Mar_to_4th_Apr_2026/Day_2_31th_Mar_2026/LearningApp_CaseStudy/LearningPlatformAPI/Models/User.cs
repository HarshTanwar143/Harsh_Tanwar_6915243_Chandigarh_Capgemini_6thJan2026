using System.ComponentModel.DataAnnotations;

namespace LearningPlatformAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public Profile Profile { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}