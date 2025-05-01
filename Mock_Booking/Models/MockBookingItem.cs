using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mock_Booking.Models
{
    public class MockBookingItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BookingId { get; set; } = null!;

        [ForeignKey(nameof(BookingId))]
        public MockBookingEntity Booking { get; set; } = null!;

        [Required]
        public string TicketCategory { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string SpecialDetails { get; set; }
    }
}
