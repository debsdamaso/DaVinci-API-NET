using DaVinci.Models;

namespace DaVinci.Repository.Interfaces
{
    public interface IClientesRepository
    {
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<Clientes> GetByIdAsync(int id);
        Task AddAsync(Clientes clientes);
        Task UpdateAsync(Clientes clientes);
        Task DeleteAsync(int id);
    }
}
