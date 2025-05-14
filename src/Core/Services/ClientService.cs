// Core/Services/ClientService.cs
using tarea9_DAEA.Core.Interfaces;
using tarea9_DAEA.src.Infrastructure.Persistence.Models;

namespace tarea9_DAEA.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task AddClientAsync(Client client)
        {
            await _clientRepository.AddAsync(client);
        }
    }
}