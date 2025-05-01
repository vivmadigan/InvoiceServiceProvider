using Microsoft.EntityFrameworkCore;
using Mock_Booking.Data;
using Mock_Booking.Protos;
using Mock_Booking.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<MockDataContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("LocalMockDB")));

builder.Services.AddScoped<MockBookingService>();

builder.Services.AddGrpcClient<InvoiceContract.InvoiceContractClient>(o =>
{
    o.Address = new Uri(builder.Configuration["InvoiceMicroserviceUrl"]);
});

var app = builder.Build();



app.MapOpenApi();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
