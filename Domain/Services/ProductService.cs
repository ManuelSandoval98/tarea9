using tarea9_DAEA.Domain.Entities;
using tarea9_DAEA.Domain.Ports;

namespace tarea9_DAEA.Domain.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public List<Product> GetAllProducts() => _repository.GetAll();

    public void AddProduct(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("El nombre es obligatorio.");

        if (product.Price <= 0)
            throw new ArgumentException("El precio debe ser mayor que cero.");

        _repository.Add(product);
    }
}
