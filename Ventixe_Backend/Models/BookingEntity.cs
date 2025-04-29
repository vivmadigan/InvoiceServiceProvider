using System.ComponentModel.DataAnnotations;

namespace Ventixe_Backend.Models
{
    public class BookingEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // Who made the booking
        public string UserId { get; set; } = null!;
        public UserEntity User { get; set; } = null!;

        // Which event
        public string EventId { get; set; } = null!;
        public EventEntity Event { get; set; } = null!;

        // Header‐level metadata if you need it
        public DateTime BookingDate { get; set; } = DateTime.Now;

        // The individual items (Silver/Gold/Bronze, etc.)
        public virtual ICollection<BookingItemEntity> BookingItems { get; set; }
            = new List<BookingItemEntity>();
    }
}
