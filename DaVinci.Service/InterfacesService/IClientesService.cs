using DaVinci.Models;

namespace DaVinci.Service.InterfacesService
{
    public interface IClientesService
    {
        Task<IEnumerable<Clientes>> GetAllClientesAsync();
        Task<Clientes> GetClientesByIdAsync(int id);
        Task<Clientes> CreateClientesAsync(Clientes clientes);
        Task UpdateClientesAsync(int id, Clientes clientes);
        Task DeleteClientesAsync(int id);
    }
}
