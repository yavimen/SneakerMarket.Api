using Microsoft.EntityFrameworkCore;
using SneakerMarket.Api;
using SneakerMarket.Api.Models;
using SneakerMarket.Api.Repository.Contracts;

namespace Repository
{
    public class CustomerInfoRepository : RepositoryBase<CustomerInfo>, ICustomerInfoRepository
    {
        public CustomerInfoRepository(ApplicationContext context):
            base(context){ }

        public void CreateCustomerInfo(CustomerInfo contact)
        {
            Create(contact);
        }

        public void DeleteCustomerInfo(CustomerInfo contact)
        {
            Delete(contact);
        }

        public async Task<CustomerInfo?> GetCustomerInfoByIdAsync(Guid id)
        {
            return await FindByCondition(a => a.CustomerAccountId.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CustomerInfo>> GetAllCustomerInfosAsync()
        {
            return await FindAll()
                .OrderBy(a => a.City)
                .ToListAsync();
        }

        public void UpdateCustomerInfo(CustomerInfo contact)
        {
            Update(contact);
        }
    }
}
