using Moq;
using tarea9_DAEA.API;
using tarea9_DAEA.Domain.Entities;
using tarea9_DAEA.Domain.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using tarea9_DAEA.Adapters.Repositories;
using tarea9_DAEA.Domain.Ports;
using Xunit;

namespace tarea9_DAEA.IntegrationTests
{
    public class ProductEndpointsTests : IClassFixture<WebApplicationFactory<TestProgram>> // Usamos WebApplicationFactory<TestProgram>
    {
        private readonly WebApplicationFactory<TestProgram> _factory;

        public ProductEndpointsTests(WebApplicationFactory<TestProgram> factory)
        {
            _factory = factory;
        }

        // Test para verificar que se pueden obtener productos
        [Fact]
        public async Task GetProducts_ReturnsOkStatus()
        {
            // Arrange
            var client = _factory.CreateClient();  // Crear un cliente HTTP para hacer solicitudes

            // Act
            var response = await client.GetAsync("/products");

            // Assert
            response.EnsureSuccessStatusCode();  // Verifica que el estado sea 2xx
        }

        // Test para verificar que se puede agregar un producto
        [Fact]
        public async Task AddProduct_ReturnsCreatedStatus()
        {
            // Arrange
            var client = _factory.CreateClient();
            var newProduct = new Product { Id = 1, Name = "Nuevo Producto", Price = 100 };

            // Act
            var response = await client.PostAsJsonAsync("/products", newProduct);

            // Assert
            response.EnsureSuccessStatusCode();  // Verifica que la respuesta sea 2xx
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);  // Asegura que el código de estado sea 201
        }

        // Test para manejar error de validación en el nombre del producto
        [Fact]
        public async Task AddProduct_WithInvalidData_ReturnsBadRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            var invalidProduct = new Product { Id = 1, Name = "", Price = 100 };  // Nombre vacío

            // Act
            var response = await client.PostAsJsonAsync("/products", invalidProduct);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);  // Asegura que el código de estado sea 400
        }
    }

    // Clase de prueba que usa WebApplicationFactory sin cambiar Program.cs
    public class TestProgram
    {
        public static void Main(string[] args)
        {
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
        }
    }
}
