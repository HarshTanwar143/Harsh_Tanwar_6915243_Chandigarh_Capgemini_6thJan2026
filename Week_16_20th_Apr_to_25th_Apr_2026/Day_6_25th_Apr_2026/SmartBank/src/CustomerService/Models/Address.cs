using System.ComponentModel.DataAnnotations;

namespace CustomerService.Models
{
    public class Address
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(200)] public string Line1 { get; set; } = string.Empty;
        [MaxLength(200)] public string? Line2 { get; set; }

        [Required, MaxLength(80)] public string City { get; set; } = string.Empty;
        [Required, MaxLength(80)] public string State { get; set; } = string.Empty;
        [Required, MaxLength(10)] public string PinCode { get; set; } = string.Empty;
        [Required, MaxLength(80)] public string Country { get; set; } = "India";

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
