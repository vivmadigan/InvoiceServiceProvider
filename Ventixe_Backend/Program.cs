using Microsoft.EntityFrameworkCore;
using Ventixe_Backend.Data;
using Ventixe_Backend.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddGrpc();

builder.Services.AddDbContext<DataContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));


var app = builder.Build();



app.MapOpenApi();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapGrpcService<InvoiceService>();
app.MapGet("/", () => "Use a gRPC client to connect to this server.");
app.MapControllers();

app.Run();