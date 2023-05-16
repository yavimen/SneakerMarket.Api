using SneakerMarket.Api.Models;

namespace Contracts
{
    public interface IContractRepository
    {

        Task<Contract?> GetContractBySupplierContactIdAsync(Guid id);

        Task<Contract?> GetContractByPMContactIdAsync(Guid id);

        Task<IEnumerable<Contract>> GetAllContractsWithDetailsAsync();

        void CreateContract(Contract account);

        void UpdateContract(Contract account);

        void DeleteContract(Contract account);
    }
}
