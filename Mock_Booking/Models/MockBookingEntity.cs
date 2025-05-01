namespace Mock_Booking.Models
{
    public class MockBookingEntity
    {
        public string BookingId { get; set; } = null!;
        public string UserId { get; set; } = null!;

        // Snapshot of who’s booking
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserAddress { get; set; } = null!;
        public string UserPhone { get; set; } = null!;

        // Snapshot of the event
        public string EventId { get; set; } = null!;
        public string EventName { get; set; } = null!;
        public DateTime EventDate { get; set; }  // new: when the event actually occurs
        public string EventLocation { get; set; } = null!;

        // Snapshot of the event owner
        public string EventOwnerName { get; set; } = null!;
        public string EventOwnerEmail { get; set; } = null!;
        public string EventOwnerAddress { get; set; } = null!;
        public string EventOwnerPhone { get; set; } = null!;

        // Booking details
        public DateTime BookingDate { get; set; }
        public bool Paid { get; set; }
        public string PaymentMethod { get; set; } = null!;   
        public string Currency { get; set; } = "SEK";

        // Optional extras
        public string? DiscountCode { get; set; }           
        public string? SpecialRequests { get; set; }          

        public List<MockBookingItem> Items { get; set; } = new List<MockBookingItem>();
    }
}
