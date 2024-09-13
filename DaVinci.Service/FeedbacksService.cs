using DaVinci.Models;
using DaVinci.Repository.Interfaces;
using DaVinci.Service.InterfacesService;

namespace DaVinci.Service
{
    public class FeedbacksService : IFeedbacksService
    {
        private readonly IFeedbacksRepository _feedbacksRepository;

        public FeedbacksService(IFeedbacksRepository feedbacksRepository)
        {
            _feedbacksRepository = feedbacksRepository;
        }

        public async Task<IEnumerable<Feedbacks>> GetAllFeedbacksAsync()
        {
            return await _feedbacksRepository.GetAllAsync();
        }

        public async Task<Feedbacks> GetFeedbacksByIdAsync(int id)
        {
            return await _feedbacksRepository.GetByIdAsync(id);
        }

        public async Task<Feedbacks> CreateFeedbacksAsync(Feedbacks feedbacks)
        {
            await _feedbacksRepository.AddAsync(feedbacks);
            return feedbacks;
        }

        public async Task UpdateFeedbacksAsync(int id, Feedbacks feedbacks)
        {
            await _feedbacksRepository.UpdateAsync(feedbacks);
        }

        public async Task DeleteFeedbacksAsync(int id)
        {
            await _feedbacksRepository.DeleteAsync(id);
        }
    }
}
