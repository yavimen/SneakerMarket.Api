using SneakerMarket.Api.Models;

namespace Contracts
{
    public interface IShoesMainRepository
    {        
        Task<IEnumerable<ShoesMain>> GetAllShoesMainWithDetailsAsync();

        Task<ShoesMain?> GetShoesMainAsync(Guid id);

        Task<IEnumerable<ShoesMain>> GetAllShoesMainByCategoryWithDetailsAsync(string category);

        void CreateShoesMain(ShoesMain shoesMain);

        void UpdateShoesMain(ShoesMain shoesMain);

        void DeleteShoesMain(ShoesMain shoesMain);
    }
}
