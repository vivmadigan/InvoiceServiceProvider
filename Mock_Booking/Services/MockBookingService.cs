using Mock_Booking.Forms;
using Mock_Booking.Models;
using Mock_Booking.Protos;
using Mock_Booking.Data;

namespace Mock_Booking.Services
{
    public class MockBookingService
    {
        private readonly MockDataContext _mockDataContext;
        private readonly InvoiceContract.InvoiceContractClient _invoiceClient;

        public MockBookingService(
            MockDataContext mockDataContext,
            InvoiceContract.InvoiceContractClient invoiceClient)
        {
            _mockDataContext = mockDataContext;
            _invoiceClient = invoiceClient;
        }

        public async Task<bool> CreateBookingAsync(BookingFormModel form)
        {
            // 1) Save the booking
            var booking = new MockBookingEntity
            {
                UserId = form.UserId,
                UserName = form.UserName,
                UserEmail = form.UserEmail,
                UserAddress = form.UserAddress,
                UserPhone = form.UserPhone,
                EventId = form.EventId,
                EventName = form.EventName,
                EventDate = form.EventDate,
                EventLocation = form.EventLocation,
                EventOwnerName = form.EventOwnerName,
                EventOwnerEmail = form.EventOwnerEmail,
                EventOwnerAddress = form.EventOwnerAddress,
                EventOwnerPhone = form.EventOwnerPhone,
                Paid = form.Paid,
                PaymentMethod = form.PaymentMethod,
                Currency = form.Currency,
                DiscountCode = form.DiscountCode,
                SpecialRequests = form.SpecialRequests
            };
            foreach (var item in form.Items)
            {
                booking.Items.Add(new MockBookingItem
                {
                    TicketCategory = item.TicketCategory,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    SpecialDetails = item.SpecialDetails ?? string.Empty
                });
            }
            _mockDataContext.Bookings.Add(booking);
            try
            {
                await _mockDataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            // 2) Build the InvoiceCreationRequest
            var invoiceRequest = new InvoiceCreationRequest
            {
                BookingId = booking.BookingId,
                UserId = booking.UserId,
                UserName = booking.UserName,
                UserEmail = booking.UserEmail,
                UserAddress = booking.UserAddress,
                UserPhone = booking.UserPhone,
                EventId = booking.EventId,
                EventName = booking.EventName,
                EventOwnerName = booking.EventOwnerName,
                EventOwnerEmail = booking.EventOwnerEmail,
                EventOwnerAddress = booking.EventOwnerAddress,
                EventOwnerPhone = booking.EventOwnerPhone,
                InvoicePaid = booking.Paid
            };
            foreach (var bi in booking.Items)
            {
                invoiceRequest.Items.Add(new InvoiceItem
                {
                    TicketCategory = bi.TicketCategory,
                    Price = (double)bi.Price,
                    Quantity = bi.Quantity
                });
            }

            // 3) Send to Invoice service
            var invoiceResponse = await _invoiceClient
                .CreateInvoiceContractAsync(invoiceRequest);

            if (!invoiceResponse.Success)
            {
                // Handle failure (log, throw, etc.)
                return false;
            }

            // 4) Optionally, store the returned InvoiceId on your booking:
            // booking.InvoiceId = invoiceResponse.InvoiceId;
            // await _mockDataContext.SaveChangesAsync();

            return true;
        }
    }

}
