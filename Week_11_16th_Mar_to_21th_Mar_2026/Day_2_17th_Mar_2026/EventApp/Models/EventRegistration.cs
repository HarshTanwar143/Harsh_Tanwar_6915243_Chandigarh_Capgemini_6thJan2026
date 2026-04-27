using System.ComponentModel.DataAnnotations;

namespace EventApp.Models
{
    public class EventRegistration
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Participant name is required")]
        public string ParticipantName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Event name is required")]
        public string EventName { get; set; }
    }
}