using DaVinci.Database;
using DaVinci.Models;
using DaVinci.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaVinci.Repository
{
    public class FeedbacksRepository : IFeedbacksRepository
    {
        private readonly AzureDbContext _context;

        public FeedbacksRepository(AzureDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedbacks>> GetAllAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<Feedbacks> GetByIdAsync(int id)
        {
            return await _context.Feedbacks.FindAsync(id);
        }

        public async Task AddAsync(Feedbacks feedbacks)
        {
            _context.Feedbacks.Add(feedbacks);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Feedbacks feedbacks)
        {
            _context.Feedbacks.Update(feedbacks);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var feedbacks = await _context.Feedbacks.FindAsync(id);
            if (feedbacks != null)
            {
                _context.Feedbacks.Remove(feedbacks);
                await _context.SaveChangesAsync();
            }
        }
    }
}
