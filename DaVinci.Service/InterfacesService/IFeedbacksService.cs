using DaVinci.Models;

namespace DaVinci.Service.InterfacesService
{
    public interface IFeedbacksService
    {
        Task<IEnumerable<Feedbacks>> GetAllFeedbacksAsync();
        Task<Feedbacks> GetFeedbacksByIdAsync(int id);
        Task<Feedbacks> CreateFeedbacksAsync(Feedbacks feedbacks);
        Task UpdateFeedbacksAsync(int id, Feedbacks feedbacks);
        Task DeleteFeedbacksAsync(int id);
    }
}
