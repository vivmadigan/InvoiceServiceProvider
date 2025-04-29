using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ventixe_Backend.Models
{
    public class InvoiceEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // Auto-incrementing for human‐friendly numbers
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sequence { get; set; }
        [NotMapped]
        public string InvoiceNumber => $"INV{Sequence:00000}";

        [Column(TypeName = "date")]
        public DateTime IssuedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        // Which booking this invoice is for
        public string BookingId { get; set; } = null!;
        public BookingEntity Booking { get; set; } = null!;

        // Who gets billed
        public string UserId { get; set; } = null!;
        public UserEntity User { get; set; } = null!;

        // Which event
        public string EventId { get; set; } = null!;
        public EventEntity Event { get; set; } = null!;

        // Status: Paid, Unpaid, Overdue…
        public int StatusId { get; set; }
        public StatusEntity Status { get; set; } = null!;

        // Monetary totals (you can recalc from BookingItems if you prefer)
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Fee { get; set; }
        public decimal Total { get; set; }

        // The lines on the invoice
        public virtual ICollection<BookingItemEntity> BookingItems { get; set; }
            = new List<BookingItemEntity>();
    }
}
