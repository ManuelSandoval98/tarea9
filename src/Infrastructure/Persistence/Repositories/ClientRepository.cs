// Infrastructure/Persistence/Repositories/ClientRepository.cs
using Microsoft.EntityFrameworkCore;
using tarea9_DAEA.Core.Interfaces;
using tarea9_DAEA.src.Infrastructure.Persistence.Models;

namespace tarea9_DAEA.Infrastructure.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task AddAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }
    }
}