using Contracts;
using Microsoft.EntityFrameworkCore;
using SneakerMarket.Api;
using SneakerMarket.Api.Models;

namespace Repository
{
    public class CustomerOrderRepository : RepositoryBase<CustomerOrder>, ICustomerOrderRepository
    {
        public CustomerOrderRepository(ApplicationContext context) :
            base(context)
        { }

        public void CreateCustomerOrder(CustomerOrder customerOrder)
        {
            Create(customerOrder);
        }

        public void DeleteCustomerOrder(CustomerOrder customerOrder)
        {
            Delete(customerOrder);
        }

        public async Task<CustomerOrder?> GetCustomerOrderByIdAsync(Guid id)
        {
            return await FindByCondition(a => a.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<CustomerOrder?> GetCustomerOrderByIdWithDetailsAsync(Guid id)
        {
            return await FindByCondition(a => a.Id.Equals(id))
                .Include(a => a.OrderShoesInfoMaps)
                    .ThenInclude(o => o.AdditionalInfo)
                        .ThenInclude(a => a.ShoesMainId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CustomerOrder>> GetAllCustomerOrdersWithDetailsAsync(Guid customerAccountId)
        {
            return await FindAll()
                .Include(a => a.OrderShoesInfoMaps)
                    .ThenInclude(o => o.AdditionalInfo)
                        .ThenInclude(a => a.ShoesMainId)
                .Where(o => o.CustomerAccountId == customerAccountId)
                .ToListAsync();
        }

        public void UpdateCustomerOrder(CustomerOrder customerOrder)
        {
            Update(customerOrder);
        }
    }
}
