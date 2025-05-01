namespace Mock_Booking.Models
{
    public class MockBookingItem
    {
        public string TicketCategory { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string SpecialDetails { get; set; }
    }
}
