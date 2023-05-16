using Contracts;
using Microsoft.EntityFrameworkCore;
using SneakerMarket.Api;
using SneakerMarket.Api.Models;

namespace Repository
{
    public class OrderShoesInfoMapRepository : RepositoryBase<OrderShoesInfoMap>, IOrderShoesInfoMapRepository
    {
        public OrderShoesInfoMapRepository(ApplicationContext context):
            base(context){ }

        public void CreateOrderShoesInfoMap(OrderShoesInfoMap orderShoesInfoMap)
        {
            Create(orderShoesInfoMap);
        }

        public void DeleteOrderShoesInfoMap(OrderShoesInfoMap orderShoesInfoMap)
        {
            Delete(orderShoesInfoMap);
        }

        public async Task<OrderShoesInfoMap?> GetOrderShoesInfoMapByIdAsync(Guid id)
        {
            return await FindByCondition(a => a.Id.Equals(id))
                .Include(a=>a.AdditionalInfo)
                .Include(a=>a.CustomerOrder)
                .FirstOrDefaultAsync();
        }

        public void UpdateOrderShoesInfoMap(OrderShoesInfoMap orderShoesInfoMap)
        {
            Update(orderShoesInfoMap);
        }
    }
}
