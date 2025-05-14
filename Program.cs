using Microsoft.EntityFrameworkCore;
using tarea9_DAEA.Core.Interfaces;
using tarea9_DAEA.Core.Services;
using tarea9_DAEA.Infrastructure.Persistence.Repositories;
using tarea9_DAEA.src.Infrastructure.Persistence.Models;
using tarea9_DAEA.API;
using tarea9_DAEA.Adapters.Repositories;
using tarea9_DAEA.Domain.Ports;
using tarea9_DAEA.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext para usar MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositorios y servicios
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

// Registrar otros servicios y repositorios
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddScoped<ProductService>();

// Agregar controladores
builder.Services.AddControllers(); // Esto asegura que los controladores se registren correctamente

// Agregar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el middleware de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear los endpoints del producto
app.MapProductEndpoints(); // De tus compañeros para los productos

// Mapear los controladores generados
app.MapControllers(); // Esto asegura que los controladores sean expuestos como endpoints

app.Run();