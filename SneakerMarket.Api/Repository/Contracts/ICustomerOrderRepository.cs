using SneakerMarket.Api.Models;

namespace Contracts
{
    public interface ICustomerOrderRepository
    {

        Task<CustomerOrder?> GetCustomerOrderByIdWithDetailsAsync(Guid id);

        Task<CustomerOrder?> GetCustomerOrderByIdAsync(Guid id);

        Task<IEnumerable<CustomerOrder>> GetAllCustomerOrdersWithDetailsAsync(Guid customerAccountId);

        void CreateCustomerOrder(CustomerOrder customerOrder);

        void UpdateCustomerOrder(CustomerOrder customerOrder);

        void DeleteCustomerOrder(CustomerOrder customerOrder);
    }
}
