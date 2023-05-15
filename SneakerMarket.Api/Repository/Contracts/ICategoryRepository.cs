using SneakerMarket.Api.Models;

namespace SneakerMarket.Api.Repository.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category?> GetCategoryByIdAsync(Guid id);
    }
}
