using SneakerMarket.Api.Models;

namespace SneakerMarket.Api.Repository.Contracts
{
    public interface ICustomerInfoRepository
    {
        Task<IEnumerable<CustomerInfo>> GetAllCustomerInfosAsync();

        Task<CustomerInfo?> GetCustomerInfoByIdAsync(Guid id);

        void CreateCustomerInfo(CustomerInfo contact);

        void UpdateCustomerInfo(CustomerInfo contact);

        void DeleteCustomerInfo(CustomerInfo contact);
    }
}
