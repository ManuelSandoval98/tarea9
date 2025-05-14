using tarea9_DAEA.API;
using tarea9_DAEA.Adapters.Repositories;
using tarea9_DAEA.Domain.Ports;
using tarea9_DAEA.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Mapear los endpoints del producto
app.MapProductEndpoints();

app.Run();