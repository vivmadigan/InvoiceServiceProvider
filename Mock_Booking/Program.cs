using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Mock_Booking.Data;
using Mock_Booking.Protos;
using Mock_Booking.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<MockDataContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("LocalMockDB")));

builder.Services.AddSingleton(sp =>
{
    // Will now find ConnectionStrings:ServiceBus
    var conn = builder.Configuration.GetConnectionString("ServiceBus");
    return new ServiceBusClient(conn);
});

builder.Services.AddScoped<MockBookingService>();


var app = builder.Build();



app.MapOpenApi();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
