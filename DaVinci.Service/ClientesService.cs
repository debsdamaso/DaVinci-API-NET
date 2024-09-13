using DaVinci.Models;
using DaVinci.Repository.Interfaces;
using DaVinci.Service.InterfacesService;

namespace DaVinci.Service
{
    public class ClientesService : IClientesService
    {
        private readonly IClientesRepository _clientesRepository;

        public ClientesService(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        public async Task<IEnumerable<Clientes>> GetAllClientesAsync()
        {
            return await _clientesRepository.GetAllAsync();
        }

        public async Task<Clientes> GetClientesByIdAsync(int id)
        {
            return await _clientesRepository.GetByIdAsync(id);
        }

        public async Task<Clientes> CreateClientesAsync(Clientes clientes)
        {
            await _clientesRepository.AddAsync(clientes);
            return clientes;
        }

        public async Task UpdateClientesAsync(int id, Clientes clientes)
        {
            await _clientesRepository.UpdateAsync(clientes);
        }

        public async Task DeleteClientesAsync(int id)
        {
            await _clientesRepository.DeleteAsync(id);
        }
    }
}

