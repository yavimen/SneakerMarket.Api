using Contracts;
using Microsoft.EntityFrameworkCore;
using SneakerMarket.Api;
using SneakerMarket.Api.Models;

namespace Repository
{
    public class ContractRepository : RepositoryBase<Contract>, IContractRepository
    {
        public ContractRepository(ApplicationContext context):
            base(context){ }
            
        public void CreateContract(Contract contract)
        {
            Create(contract);
        }

        public void DeleteContract(Contract contract)
        {
            Delete(contract);
        }

        public async Task<Contract?> GetContractByIdAsync(Guid id)
        {
            return await FindByCondition(a => a.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<Contract?> GetContractBySupplierContactIdAsync(Guid id)
        {
            return await FindByCondition(a => a.Id.Equals(id))
                .Include(a => a.Pmcontact)
                .Include(a => a.SupplierContact).Include(a => a.ShoesMains)
                    .ThenInclude(s => s.ShoesAdditionalInfos)
                .Where(a=> a.SupplierContactId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Contract?> GetContractByPMContactIdAsync(Guid id)
        {
            return await FindByCondition(a => a.Id.Equals(id))
                .Include(a => a.Pmcontact)
                .Include(a => a.SupplierContact)
                .Include(a => a.ShoesMains)
                    .ThenInclude(s => s.ShoesAdditionalInfos)
                .Where(a=> a.PmcontactId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contract>> GetAllContractsWithDetailsAsync()
        {
            return await FindAll()
                .Include(a => a.Pmcontact)
                .Include(a => a.SupplierContact)
                .Include(a => a.ShoesMains)
                    .ThenInclude(s => s.ShoesAdditionalInfos)
                .OrderBy(a => a.DateStamp)
                .ToListAsync();
        }

        public void UpdateContract(Contract contract)
        {
            Update(contract);
        }
    }
}
