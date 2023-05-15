using SneakerMarket.Api.Models;

namespace Contracts
{
    public interface IShoesAdditionalInfoRepository
    {        
        Task<ShoesAdditionalInfo?> GetShoesAdditionalInfoAsync(Guid id);

        Task<IEnumerable<ShoesAdditionalInfo>> GetAllShoesAdditionalInfoByShoesMainWithDetailsAsync(Guid shoesMainId);

        void CreateShoesAdditionalInfo(ShoesAdditionalInfo shoesAdditionalInfo);

        void UpdateShoesAdditionalInfo(ShoesAdditionalInfo shoesAdditionalInfo);

        void DeleteShoesAdditionalInfo(ShoesAdditionalInfo shoesAdditionalInfo);
    }
}
