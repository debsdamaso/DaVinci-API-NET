using DaVinci.Models;
using DaVinci.Repository.Interfaces;
using DaVinci.Service.InterfacesService;

namespace DaVinci.Service
{
    public class ProdutosService : IProdutosService
    {
        private readonly IProdutosRepository _produtosRepository;

        public ProdutosService(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public async Task<IEnumerable<Produtos>> GetAllProdutosAsync()
        {
            return await _produtosRepository.GetAllAsync();
        }

        public async Task<Produtos> GetProdutosByIdAsync(int id)
        {
            return await _produtosRepository.GetByIdAsync(id);
        }

        public async Task<Produtos> CreateProdutosAsync(Produtos produtos)
        {
            await _produtosRepository.AddAsync(produtos);
            return produtos;
        }

        public async Task UpdateProdutosAsync(int id, Produtos produtos)
        {
            await _produtosRepository.UpdateAsync(produtos);
        }

        public async Task DeleteProdutosAsync(int id)
        {
            await _produtosRepository.DeleteAsync(id);
        }
    }
}
