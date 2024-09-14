using Moq;
using DaVinci.Models;
using DaVinci.Service;
using DaVinci.Repository.Interfaces;

namespace DaVinci.Services.Test
{
    public class FeedbacksTest
    {
        private readonly Mock<IFeedbacksRepository> _mockFeedbacksRepository;
        private readonly FeedbacksService _feedbacksService;

        public FeedbacksTest()
        {
            _mockFeedbacksRepository = new Mock<IFeedbacksRepository>();
            _feedbacksService = new FeedbacksService(_mockFeedbacksRepository.Object);
        }

        [Fact]
        public async Task GetAllFeedbacks_ShouldReturnListOfFeedbacks()
        {
            var feedbacksList = new List<Feedbacks>
            {
                new Feedbacks { IdFeedback = 1, Comentario = "Muito bom", Avaliacao = 5 },
                new Feedbacks { IdFeedback = 2, Comentario = "Regular", Avaliacao = 3 }
            };

            _mockFeedbacksRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(feedbacksList);

            var result = await _feedbacksService.GetAllFeedbacksAsync();
            var resultList = result.ToList();

            Assert.NotNull(resultList);
            Assert.Equal(2, resultList.Count);
            Assert.Equal("Muito bom", resultList[0].Comentario);
            Assert.Equal(5, resultList[0].Avaliacao);
        }

        [Fact]
        public async Task GetFeedbackById_ShouldReturnFeedback_WhenFeedbackExists()
        {
            var feedback = new Feedbacks { IdFeedback = 1, Comentario = "Excelente", Avaliacao = 5 };

            _mockFeedbacksRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(feedback);

            var result = await _feedbacksService.GetFeedbacksByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Excelente", result.Comentario);
        }

        [Fact]
        public async Task GetFeedbackById_ShouldReturnNull_WhenFeedbackDoesNotExist()
        {
            _mockFeedbacksRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Feedbacks?)null);

            var result = await _feedbacksService.GetFeedbacksByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task CreateFeedback_ShouldAddFeedback()
        {
            var newFeedback = new Feedbacks { Comentario = "Ótimo produto", Avaliacao = 5 };

            await _feedbacksService.CreateFeedbacksAsync(newFeedback);

            _mockFeedbacksRepository.Verify(repo => repo.AddAsync(newFeedback), Times.Once);
        }
    }
}
