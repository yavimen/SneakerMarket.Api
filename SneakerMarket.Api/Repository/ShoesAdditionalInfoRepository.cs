using Contracts;
using Microsoft.EntityFrameworkCore;
using SneakerMarket.Api;
using SneakerMarket.Api.Models;

namespace Repository
{
    public class ShoesAdditionalInfoRepository : RepositoryBase<ShoesAdditionalInfo>, IShoesAdditionalInfoRepository
    {
        public ShoesAdditionalInfoRepository(ApplicationContext context):
            base(context){ }

        public void CreateShoesAdditionalInfo(ShoesAdditionalInfo shoesAdditionalInfo)
        {
            Create(shoesAdditionalInfo);
        }

        public void DeleteShoesAdditionalInfo(ShoesAdditionalInfo shoesAdditionalInfo)
        {
            Delete(shoesAdditionalInfo);
        }

        public async Task<IEnumerable<ShoesAdditionalInfo>> GetAllShoesAdditionalInfoByShoesMainWithDetailsAsync(Guid shoesMainId)
        {
            return await FindAll()
                .Include(s => s.ShoesMain)
                .Where(s => s.ShoesMain.Id == shoesMainId)
                .OrderBy(f => f.ShoesSize)
                .ToListAsync();
        }
        public async Task<ShoesAdditionalInfo?> GetShoesAdditionalInfoAsync(Guid id) 
        {
            return await FindByCondition(s => s.Id  == id)
                .FirstOrDefaultAsync();
        }

        public void UpdateShoesAdditionalInfo(ShoesAdditionalInfo shoesAdditionalInfo)
        {
            Update(shoesAdditionalInfo);
        }
    }
}
