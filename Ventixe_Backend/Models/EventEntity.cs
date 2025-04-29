using System.ComponentModel.DataAnnotations;

namespace Ventixe_Backend.Models
{
    public class EventEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string EventName { get; set; } = null!;
        public string EventDescription { get; set; } = null!;
        public DateTime EventDate { get; set; }

        public string Client { get; set; } = null!;
        public string ClientAddress { get; set; } = null!;
        public string ClientEmail { get; set; } = null!;
        public string ClientPhone { get; set; } = null!;

        public virtual ICollection<InvoiceEntity> Invoices { get; set; }
            = new List<InvoiceEntity>();
    }
}
