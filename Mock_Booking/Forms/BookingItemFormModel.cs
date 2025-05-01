using System.ComponentModel.DataAnnotations;

namespace Mock_Booking.Forms
{
    public class BookingItemFormModel
    {
        [Required, MaxLength(100)]
        public string TicketCategory { get; set; } = null!;

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        // If you need any per‐item notes
        public string? SpecialDetails { get; set; }
    }
}
