using System.ComponentModel.DataAnnotations;

namespace Ventixe_Backend.Models
{
    public class PaymentStatus
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
        public virtual ICollection<InvoiceEntity> Invoices { get; set; }
            = new List<InvoiceEntity>();
    }
}
