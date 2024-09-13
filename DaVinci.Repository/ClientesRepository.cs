using DaVinci.Database;
using DaVinci.Models;
using DaVinci.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaVinci.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly AzureDbContext _context;

        public ClientesRepository(AzureDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Clientes>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Clientes> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task AddAsync(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Clientes clientes)
        {
            _context.Clientes.Update(clientes);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes != null)
            {
                _context.Clientes.Remove(clientes);
                await _context.SaveChangesAsync();
            }
        }
    }
}
