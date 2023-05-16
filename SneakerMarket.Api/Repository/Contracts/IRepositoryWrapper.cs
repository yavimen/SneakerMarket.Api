using Repository;
using SneakerMarket.Api.Repository.Contracts;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }
        IContactRepository Contact { get; }
        ICustomerInfoRepository CustomerInfo { get; }
        IAccountRoleRepository AccountRole { get; }
        IFeedbackRepository Feedback { get; }
        ICategoryRepository Category { get; }
        IShoesMainRepository ShoesMain { get; }
        IShoesAdditionalInfoRepository ShoesAdditionalInfo { get; }
        IContractRepository Contract { get; }
        ICustomerOrderRepository CustomerOrder { get; }
        IOrderShoesInfoMapRepository OrderShoesInfoMap { get; }
        Task SaveAsync();
    }
}
