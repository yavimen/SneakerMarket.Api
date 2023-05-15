using Contracts;
using Microsoft.EntityFrameworkCore;
using SneakerMarket.Api;
using SneakerMarket.Api.Models;

namespace Repository
{
    public class ShoesMainRepository : RepositoryBase<ShoesMain>, IShoesMainRepository
    {
        public ShoesMainRepository(ApplicationContext context):
            base(context){ }

        public void CreateShoesMain(ShoesMain shoesMain)
        {
            Create(shoesMain);
        }

        public void DeleteShoesMain(ShoesMain shoesMain)
        {
            Delete(shoesMain);
        }

        public async Task<IEnumerable<ShoesMain>> GetAllShoesMainByCategoryWithDetailsAsync(string category)
        {
            return await FindAll()
                .Include(s => s.ShoesAdditionalInfos)
                .Include(s => s.Category)
                .Where(s => s.Category.Category1 == category)
                .OrderBy(f => f.ShoesName)
                .ToListAsync();
        }
        public async Task<ShoesMain?> GetShoesMainAsync(Guid id) 
        {
            return await FindByCondition(s => s.Id  == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ShoesMain>> GetAllShoesMainWithDetailsAsync()
        {
            return await FindAll()
                .Include(s => s.ShoesAdditionalInfos)
                .Include(s => s.Category)
                .OrderBy(f => f.ShoesName)
                .ToListAsync();
        }

        public void UpdateShoesMain(ShoesMain shoesMain)
        {
            Update(shoesMain);
        }
    }
}
