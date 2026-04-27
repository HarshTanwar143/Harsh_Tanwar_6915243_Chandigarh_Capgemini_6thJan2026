using System.ComponentModel.DataAnnotations;

namespace EventBookingAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Range(1, 50, ErrorMessage = "You can book between 1 and 50 seats.")]
        public int SeatsBooked { get; set; }

        public DateTime BookedAt { get; set; } = DateTime.UtcNow;
    }
}
