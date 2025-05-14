using tarea9_DAEA.src.Infrastructure.Persistence.Models;

namespace tarea9_DAEA.Core.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(int id);
        Task<IEnumerable<Client>> GetAllAsync();
        Task AddAsync(Client client);
    }
}