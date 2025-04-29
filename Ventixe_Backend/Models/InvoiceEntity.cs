using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ventixe_Backend.Models
{
    public class InvoiceEntity
    {

        public string InvoiceId { get; set; } = Guid.NewGuid().ToString();
        public string BookingId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!; // snapshot
        public string UserEmail { get; set; } = null!; // snapshot
        public string EventId { get; set; } = null!;
        public string EventName { get; set; } = null!; // snapshot

        public string EventOwnerEmail { get; set; } = null!; // snapshot

        public string EventOwnerName { get; set; } = null!; // snapshot

        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }
        public virtual PaymentStatus Status{ get; set; }

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
