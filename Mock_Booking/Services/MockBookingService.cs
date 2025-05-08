using Mock_Booking.Forms;
using Mock_Booking.Models;
using Mock_Booking.Protos;
using Mock_Booking.Data;
using Mock_Booking.Dtos;
using Azure.Messaging.ServiceBus;
using System.Text.Json;

namespace Mock_Booking.Services
{
    public class MockBookingService
    {
        private readonly MockDataContext _mockDataContext;
        private readonly string _queueName = "create-invoice-entity";
        private readonly ServiceBusClient _busClient;

        public MockBookingService(
            MockDataContext mockDataContext,
            ServiceBusClient busClient
            )
        {
            _mockDataContext = mockDataContext;
            _busClient = busClient;

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
            var invoiceMsg = new InvoiceMessageDto
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
                InvoicePaid = booking.Paid,
                Items = booking.Items
                    .Select(i => new InvoiceItemDto
                    {
                        TicketCategory = i.TicketCategory,
                        Price = i.Price,
                        Quantity = i.Quantity
                    })
                    .ToList()
            };


                
            // 2) Serialize & send

            var sender = _busClient.CreateSender(_queueName);


            var jsonBody = JsonSerializer.Serialize(invoiceMsg);
            var busMessage = new ServiceBusMessage(jsonBody);

            await sender.SendMessageAsync(busMessage);
            await sender.DisposeAsync();


            return true;
        }
    }

}
