using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mock_Booking.Data;
using Mock_Booking.Forms;
using Mock_Booking.Models;
using Mock_Booking.Services;

namespace Mock_Booking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly MockBookingService _bookingService;

        public BookingController(MockBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookingFormModel form)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            
            bool result = await _bookingService.CreateBookingAsync(form);
            return result ? Ok() : Problem();

        }

      
    }
}
