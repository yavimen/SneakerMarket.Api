using SneakerMarket.Api.Repository.Contracts;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }
        IContactRepository Contact { get; }
        ICustomerInfoRepository CustomerInfo { get; }
        Task SaveAsync();
    }
}
