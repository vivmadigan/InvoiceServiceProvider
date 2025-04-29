using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ventixe_Backend.Models
{
    public class InvoiceItemEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Invoice))]
        public string InvoiceId { get; set; } = null!;
        public virtual InvoiceEntity Invoice { get; set; } = null!;

        public string TicketCategory { get; set; } = null!;  
        public decimal Price { get; set; }           
        public int Quantity { get; set; }           

        [NotMapped]
        public decimal Amount => Price * Quantity;
    }
}
