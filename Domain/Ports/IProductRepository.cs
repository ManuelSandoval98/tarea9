using tarea9_DAEA.Domain.Entities;

namespace tarea9_DAEA.Domain.Ports;

public interface IProductRepository
{
    List<Product> GetAll();
    void Add(Product product);
}
