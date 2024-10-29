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

        // Aplicando o princípio SRP - Método separado para lidar com lógica de validação
        private void ValidarCliente(Clientes cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nome))
                throw new ArgumentException("O nome do cliente é obrigatório.");
            if (string.IsNullOrWhiteSpace(cliente.Cpf) || cliente.Cpf.Length != 11)
                throw new ArgumentException("CPF inválido.");
        }

        public async Task<IEnumerable<Clientes>> GetAllClientesAsync()
        {
            return await _clientesRepository.GetAllAsync();
        }

        public async Task<Clientes> GetClientesByIdAsync(int id)
        {
            return await _clientesRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Cliente não encontrado.");
        }

        public async Task<Clientes> CreateClientesAsync(Clientes cliente)
        {
            ValidarCliente(cliente);  // Aplicando validação no momento da criação
            await _clientesRepository.AddAsync(cliente);
            return cliente;
        }

        public async Task UpdateClientesAsync(int id, Clientes cliente)
        {
            var clienteExistente = await GetClientesByIdAsync(id);
            ValidarCliente(cliente);

            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Sexo = cliente.Sexo;
            clienteExistente.Cpf = cliente.Cpf;

            await _clientesRepository.UpdateAsync(clienteExistente);
        }

        public async Task DeleteClientesAsync(int id)
        {
            var cliente = await GetClientesByIdAsync(id);
            await _clientesRepository.DeleteAsync(cliente.IdCliente);
        }
    }
}