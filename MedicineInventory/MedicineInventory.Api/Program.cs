using MedicineInventory.Application.Interfaces.Repository;
using MedicineInventory.Application.Interfaces.Service;
using MedicineInventory.Application.Services;
using MedicineInventory.Infrastructure.Data;
using MedicineInventory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//mysql connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MedicineDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IMedicineService, MedicineService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngular");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
