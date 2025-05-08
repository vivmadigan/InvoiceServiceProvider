using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Ventixe_Backend.Data;
using Ventixe_Backend.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddDbContext<DataContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));

// 2) ServiceBusClient + Processor
builder.Services.AddSingleton(sp =>
{
    // Will now find ConnectionStrings:ServiceBus
    var conn = builder.Configuration.GetConnectionString("ServiceBus");
    return new ServiceBusClient(conn);
});

builder.Services.AddSingleton(sp =>
{
    var client = sp.GetRequiredService<ServiceBusClient>();
    var options = new ServiceBusProcessorOptions { AutoCompleteMessages = false };
    return client.CreateProcessor("create-invoice-entity", options);
});

// 3) Hosted worker that pumps messages off the queue
builder.Services.AddHostedService<InvoiceQueueHandler>();


var app = builder.Build();



app.MapOpenApi();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();