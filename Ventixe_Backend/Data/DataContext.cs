using Microsoft.EntityFrameworkCore;
using Ventixe_Backend.Models;

namespace Ventixe_Backend.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<InvoiceItemEntity> InvoiceItems { get; set; }
    }
}
