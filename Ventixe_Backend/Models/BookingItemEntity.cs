using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ventixe_Backend.Models
{
    public class BookingItemEntity
    {
        [Key]
        public int Id { get; set; }

        // Link back to the source booking
        [ForeignKey(nameof(Booking))]
        public string BookingId { get; set; } = null!;
        public BookingEntity Booking { get; set; } = null!;

        // Link to the invoice you generate
        [ForeignKey(nameof(Invoice))]
        public string InvoiceId { get; set; } = null!;
        public InvoiceEntity Invoice { get; set; } = null!;

        // Per‐item details
        public string TicketCategory { get; set; } = null!;   // e.g. “Silver”
        public decimal Price { get; set; }            // unit price
        public int Quantity { get; set; }            // number of tickets

        // Computed in code (not stored)
        [NotMapped]
        public decimal Amount => Price * Quantity;
    }
}
