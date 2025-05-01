using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ventixe_Backend.Models
{
    public class InvoiceEntity
    {
        [Key]
        public string InvoiceId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string BookingId { get; set; } = null!;
        [Required]
        public string UserId { get; set; } = null!;

        // User (bill-to) snapshot
        [Required]
        public string UserName { get; set; } = null!; // snapshot
        [Required]
        public string UserEmail { get; set; } = null!; // snapshot
        public string? UserAddress { get; set; }  // snapshot
        public string? UserPhone { get; set; }  // snapshot

        [Required]
        public string EventId { get; set; } = null!;
        [Required]
        public string EventName { get; set; } = null!; // snapshot

        // Event owner (company) snapshot
        [Required]
        public string EventOwnerName { get; set; } = null!; // snapshot
        [Required]
        public string EventOwnerEmail { get; set; } = null!; // snapshot
        [Required]
        public string EventOwnerAddress { get; set; } = null!;  // snapshot
        [Required]
        public string EventOwnerPhone { get; set; } = null!;  // snapshot

        // Simple Boolean for if the event was paid for at the time of booking
        public bool InvoicePaid { get; set; } // snapshot

        public DateTime IssuedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Fee { get; set; }
        public decimal Total { get; set; }

        public ICollection<InvoiceItemEntity> InvoiceItems { get; set; }
            = new List<InvoiceItemEntity>();

    }
}
