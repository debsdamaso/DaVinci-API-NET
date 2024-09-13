using DaVinci.Models;

namespace DaVinci.Service.InterfacesService
{
    public interface IProdutosService
    {
        Task<IEnumerable<Produtos>> GetAllProdutosAsync();
        Task<Produtos> GetProdutosByIdAsync(int id);
        Task<Produtos> CreateProdutosAsync(Produtos produtos);
        Task UpdateProdutosAsync(int id, Produtos produtos);
        Task DeleteProdutosAsync(int id);
    }
}
