using DaVinci.Database;
using DaVinci.Models;
using DaVinci.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaVinci.Repository
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly AzureDbContext _context;

        public ProdutosRepository(AzureDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produtos>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produtos> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task AddAsync(Produtos produtos)
        {
            _context.Produtos.Add(produtos);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produtos produtos)
        {
            _context.Produtos.Update(produtos);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produtos = await _context.Produtos.FindAsync(id);
            if (produtos != null)
            {
                _context.Produtos.Remove(produtos);
                await _context.SaveChangesAsync();
            }
        }
    }
}
