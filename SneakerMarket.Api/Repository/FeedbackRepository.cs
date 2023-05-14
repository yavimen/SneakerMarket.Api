using Contracts;
using Microsoft.EntityFrameworkCore;
using SneakerMarket.Api;
using SneakerMarket.Api.Models;

namespace Repository
{
    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(ApplicationContext context):
            base(context){ }

        public void CreateFeedback(Feedback feedback)
        {
            Create(feedback);
        }

        public void DeleteFeedback(Feedback feedback)
        {
            Delete(feedback);
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksByEmailWithDetailsAsync(string email)
        {
            return await FindAll()
                .Include(f => f.CustomerContact)
                    .ThenInclude(c => c.Account)
                .Include(f => f.CustomerOrder)
                .Where(f => f.CustomerContact.Account.Email == email)
                .OrderBy(f => f.Date)
                .ToListAsync();
        }
        public async Task<Feedback?> GetFeedbackAsync(Guid id) 
        {
            return await FindByCondition(f => f.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksWithDetailsAsync()
        {
            return await FindAll()
                .Include(f => f.CustomerContact)
                .Include(f => f.CustomerOrder)
                .OrderBy(f => f.Date)
                .ToListAsync();
        }

        public void UpdateFeedback(Feedback feedback)
        {
            Update(feedback);
        }
    }
}
