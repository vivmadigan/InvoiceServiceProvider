namespace Ventixe_Backend.Dtos
{
    public class InvoiceItemDto
    {
        public string TicketCategory { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
