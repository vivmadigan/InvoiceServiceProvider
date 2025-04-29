using System.ComponentModel.DataAnnotations;

namespace Ventixe_Backend.Models
{
    public class UserEntity
    {
        [Key] 
        public string Id { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public virtual ICollection<InvoiceEntity> Invoices { get; set; }
            = new List<InvoiceEntity>();

        public virtual ICollection<BookingEntity> Bookings { get; set; }
            = new List<BookingEntity>();
    }
}
