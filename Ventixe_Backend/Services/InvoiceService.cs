using Grpc.Core;
using Ventixe_Backend.Data;
using Ventixe_Backend.Models;
using Ventixe_Backend.Protos;

namespace Ventixe_Backend.Services
{
    public class InvoiceService(DataContext dataContext) : InvoiceContract.InvoiceContractBase
    {
        private readonly DataContext _dataContext = dataContext;

        private const decimal TAX_RATE = 0.25m;
        private const decimal FLAT_FEE = 10.00m;

        public override async Task<InvoiceCreationResponse> CreateInvoiceContract(InvoiceCreationRequest request, ServerCallContext context)
        {
            try
            {
                DateTime issuedDate = DateTime.UtcNow;
                DateTime? dueDate = issuedDate.AddDays(30);

                var invoice = new InvoiceEntity
                {
                    BookingId = request.BookingId,
                    UserId = request.UserId,
                    UserName = request.UserName,
                    UserEmail = request.UserEmail,
                    UserAddress = request.UserAddress,
                    UserPhone = request.UserPhone,
                    EventId = request.EventId,
                    EventName = request.EventName,
                    EventOwnerName = request.EventOwnerName,
                    EventOwnerEmail = request.EventOwnerEmail,
                    EventOwnerAddress = request.EventOwnerAddress,
                    EventOwnerPhone = request.EventOwnerPhone,
                    InvoicePaid = request.InvoicePaid,


                    IssuedDate = issuedDate,
                    DueDate = dueDate,
                    Created = DateTime.UtcNow

                };
                foreach (var item in request.Items)
                {
                    invoice.InvoiceItems.Add(new InvoiceItemEntity
                    {
                        TicketCategory = item.TicketCategory,
                        Price = (decimal)item.Price,
                        Quantity = item.Quantity
                    });
                }
                invoice.Subtotal = invoice.InvoiceItems.Sum(i => i.Amount);

                invoice.Tax = invoice.Subtotal * TAX_RATE;
                invoice.Fee = FLAT_FEE;
                invoice.Total = invoice.Subtotal + invoice.Tax + invoice.Fee;


                _dataContext.Add(invoice);
                await _dataContext.SaveChangesAsync();

                return new InvoiceCreationResponse
                {
                    Success = true,
                    Message = "Invoice created successfully"
                };
            }

            catch (Exception ex)
            {
                return new InvoiceCreationResponse
                {
                    Success = false,
                    Message = $"Error creating invoice: {ex.Message}"
                };
            }


        }
    }
}