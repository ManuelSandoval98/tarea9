using tarea9_DAEA.Domain.Entities;
using tarea9_DAEA.Domain.Ports;

namespace tarea9_DAEA.Adapters.Repositories;


public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();
    private int _idCounter = 1;

    public void Add(Product product)
    {
        product.Id = _idCounter++;
        _products.Add(product);
    }

    public List<Product> GetAll() => _products;
}
