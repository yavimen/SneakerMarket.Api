using Contracts;
using Microsoft.EntityFrameworkCore;
using SneakerMarket.Api;
using SneakerMarket.Api.Models;
using SneakerMarket.Api.Repository.Contracts;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context):
            base(context){ }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            return await FindByCondition(a => a.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await FindAll()
                .OrderBy(a => a.Category1)
                .ToListAsync();
        }
    }
}
