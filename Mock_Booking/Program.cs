using Microsoft.EntityFrameworkCore;
using Mock_Booking.Data;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<MockDataContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("LocalMockDB")));

var app = builder.Build();



app.MapOpenApi();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
