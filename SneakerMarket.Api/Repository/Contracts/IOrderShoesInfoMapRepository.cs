using SneakerMarket.Api.Models;

namespace Contracts
{
    public interface IOrderShoesInfoMapRepository
    {

        Task<OrderShoesInfoMap?> GetOrderShoesInfoMapByIdAsync(Guid id);

        void CreateOrderShoesInfoMap(OrderShoesInfoMap customerOrder);

        void UpdateOrderShoesInfoMap(OrderShoesInfoMap customerOrder);

        void DeleteOrderShoesInfoMap(OrderShoesInfoMap customerOrder);
    }
}
