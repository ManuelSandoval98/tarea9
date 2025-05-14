// API/Controllers/ClientsController.cs
using Microsoft.AspNetCore.Mvc;
using tarea9_DAEA.Core.Interfaces;
using tarea9_DAEA.src.Infrastructure.Persistence.Models;

namespace tarea9_DAEA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            var clients = await _clientService.GetClientsAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> AddClient(Client client)
        {
            await _clientService.AddClientAsync(client);
            return CreatedAtAction(nameof(GetClient), new { id = client.ClientId }, client);
        }
    }
}