using tarea9_DAEA.src.Infrastructure.Persistence.Models;

namespace tarea9_DAEA.Core.Interfaces
{
    public interface IClientService
    {
        Task<Client> GetClientByIdAsync(int id);
        Task<IEnumerable<Client>> GetClientsAsync();
        Task AddClientAsync(Client client);
    }
}