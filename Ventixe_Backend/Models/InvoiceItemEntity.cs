using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ventixe_Backend.Models
{
    public class InvoiceItemEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string InvoiceId { get; set; } = null!;
        [ForeignKey(nameof(InvoiceId))]
        public virtual InvoiceEntity Invoice { get; set; } = null!;
        [Required]

        public string TicketCategory { get; set; } = null!;
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }           

        [NotMapped]
        public decimal Amount => Price * Quantity;
    }
}
