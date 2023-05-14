using SneakerMarket.Api.Models;

namespace Contracts
{
    public interface IFeedbackRepository
    {        
        Task<IEnumerable<Feedback>> GetAllFeedbacksWithDetailsAsync();

        Task<Feedback?> GetFeedbackAsync(Guid id);

        Task<IEnumerable<Feedback>> GetAllFeedbacksByEmailWithDetailsAsync(string email);

        void CreateFeedback(Feedback feedback);

        void UpdateFeedback(Feedback feedback);

        void DeleteFeedback(Feedback feedback);
    }
}
