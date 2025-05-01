using System.ComponentModel.DataAnnotations;

namespace Mock_Booking.Forms
{
    public class BookingFormModel
    {
        [Required]
        public string UserId { get; set; } = null!;

        [Required, MaxLength(100)]
        public string UserName { get; set; } = null!;
        [Required, EmailAddress]
        public string UserEmail { get; set; } = null!;
        [Required]
        public string UserAddress { get; set; } = null!;
        [Required, Phone]
        public string UserPhone { get; set; } = null!;

        // Which event (ID) and its snapshot info
        [Required]
        public string EventId { get; set; } = null!;
        [Required, MaxLength(200)]
        public string EventName { get; set; } = null!;
        public DateTime EventDate { get; set; }
        [Required]
        public string EventLocation { get; set; } = null!;

        // Event owner snapshot
        [Required, MaxLength(100)]
        public string EventOwnerName { get; set; } = null!;
        [Required, EmailAddress]
        public string EventOwnerEmail { get; set; } = null!;
        [Required]
        public string EventOwnerAddress { get; set; } = null!;
        [Required, Phone]
        public string EventOwnerPhone { get; set; } = null!;

        // Booking details
        public bool Paid { get; set; } = false;
        [Required, MaxLength(50)]
        public string PaymentMethod { get; set; } = null!;
        [Required, MaxLength(10)]
        public string Currency { get; set; } = "SEK";

        // Optional extras
        public string? DiscountCode { get; set; }
        public string? SpecialRequests { get; set; }

        // The line‐items: ticket category + price + quantity (+ any extras)
        [Required, MinLength(1)]
        public List<BookingItemFormModel> Items { get; set; }
            = new List<BookingItemFormModel>();
    }
}
