using Microsoft.EntityFrameworkCore;
using Mock_Booking.Models;

namespace Mock_Booking.Data
{
    public class MockDataContext(DbContextOptions<MockDataContext> options) : DbContext(options)
    {
        public DbSet<MockBookingEntity> Bookings { get; set; }
        public DbSet<MockBookingItem> BookingItems { get; set; } 
    }
}
