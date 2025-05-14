using Xunit;
using Moq;
using tarea9_DAEA.Domain.Entities;
using tarea9_DAEA.Domain.Ports;
using tarea9_DAEA.Domain.Services;
using System.Collections.Generic;

namespace Tests.UnitTests.Domain
{
    public class ProductServiceTests
    {
        [Fact]
        public void GetAllProducts_ReturnsListOfProducts()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(new List<Product>
            {
                new Product { Id = 1, Name = "Producto A", Price = 50 },
                new Product { Id = 2, Name = "Producto B", Price = 150 }
            });

            var service = new ProductService(mockRepo.Object);

            // Act
            var result = service.GetAllProducts();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void AddProduct_WithValidData_CallsRepositoryAdd()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            var service = new ProductService(mockRepo.Object);
            var product = new Product { Id = 3, Name = "Teclado", Price = 100 };

            // Act
            service.AddProduct(product);

            // Assert
            mockRepo.Verify(r => r.Add(product), Times.Once);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void AddProduct_InvalidName_ThrowsArgumentException(string name)
        {
            var mockRepo = new Mock<IProductRepository>();
            var service = new ProductService(mockRepo.Object);
            var product = new Product { Name = name, Price = 100 };

            Assert.Throws<ArgumentException>(() => service.AddProduct(product));
        }

        [Fact]
        public void AddProduct_InvalidPrice_ThrowsArgumentException()
        {
            var mockRepo = new Mock<IProductRepository>();
            var service = new ProductService(mockRepo.Object);
            var product = new Product { Name = "Monitor", Price = 0 };

            Assert.Throws<ArgumentException>(() => service.AddProduct(product));
        }
    }
}
