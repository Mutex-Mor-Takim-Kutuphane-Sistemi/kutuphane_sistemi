using Microsoft.EntityFrameworkCore;
using Purple_Kutphane_Sistemi.Data;

string connectionString = "Host=localhost;Port=5432;Database=kutuphane;Username=postgres;Password=ez1234gi";

TriggerManager triggerManager = new TriggerManager(connectionString);

// Trigger'larý oluþturmak için
triggerManager.CreateSetSonOnaylanmaTarihiTrigger();
triggerManager.CreateKitapAlmaTalebiTrigger();
triggerManager.CreateKitapAlimlariTrigger();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbBaglanti>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
