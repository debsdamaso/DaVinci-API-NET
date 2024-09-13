using DaVinci.Models;

namespace DaVinci.Repository.Interfaces
{
    public interface IFeedbacksRepository
    {
        Task<IEnumerable<Feedbacks>> GetAllAsync();
        Task<Feedbacks> GetByIdAsync(int id);
        Task AddAsync(Feedbacks feedbacks);
        Task UpdateAsync(Feedbacks feedbacks);
        Task DeleteAsync(int id);
    }
}
