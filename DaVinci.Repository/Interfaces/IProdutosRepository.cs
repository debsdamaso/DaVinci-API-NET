using DaVinci.Models;

namespace DaVinci.Repository.Interfaces
{
    public interface IProdutosRepository
    {
        Task<IEnumerable<Produtos>> GetAllAsync();
        Task<Produtos> GetByIdAsync(int id);
        Task AddAsync(Produtos produtos);
        Task UpdateAsync(Produtos produtos);
        Task DeleteAsync(int id);
    }
}
