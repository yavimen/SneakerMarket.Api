using Contracts;
using SneakerMarket.Api;
using SneakerMarket.Api.Models;
using SneakerMarket.Api.Repository.Contracts;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        protected IAccountRepository? _account;
        protected IAccountRoleRepository? _accountRole;
        protected IContactRepository? _contact;
        protected ICustomerInfoRepository? _customerInfo;
        protected IFeedbackRepository? _feedback;
        protected ICategoryRepository? _category;
        protected IShoesMainRepository? _shoesMain;
        protected IShoesAdditionalInfoRepository? _shoesAdditionalInfo;
        protected IContractRepository? _contract;
        protected ICustomerOrderRepository? _customerOrder;
        protected IOrderShoesInfoMapRepository? _orderShoesInfoMap;
        protected ApplicationContext _context;

        public RepositoryWrapper(ApplicationContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IAccountRepository Account 
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_context);
                }
                return _account;
            }
        }
        public IContactRepository Contact 
        {
            get
            {
                if (_contact == null)
                {
                    _contact = new ContactRepository(_context);
                }
                return _contact;
            }
        }
        public ICustomerInfoRepository CustomerInfo 
        {
            get
            {
                if (_customerInfo == null)
                {
                    _customerInfo = new CustomerInfoRepository(_context);
                }
                return _customerInfo;
            }
        }
        public IAccountRoleRepository AccountRole 
        {
            get
            {
                if (_accountRole == null)
                {
                    _accountRole = new AccountRoleRepository(_context);
                }
                return _accountRole;
            }
        }
    
        public IFeedbackRepository Feedback
        {
            get
            {
                if (_feedback == null)
                {
                    _feedback = new FeedbackRepository(_context);
                }
                return _feedback;
            }
        }
    
        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_context);
                }
                return _category;
            }
        }
    
        public IShoesMainRepository ShoesMain
        {
            get
            {
                if (_shoesMain == null)
                {
                    _shoesMain = new ShoesMainRepository(_context);
                }
                return _shoesMain;
            }
        }
    
        public IShoesAdditionalInfoRepository ShoesAdditionalInfo
        {
            get
            {
                if (_shoesAdditionalInfo == null)
                {
                    _shoesAdditionalInfo = new ShoesAdditionalInfoRepository(_context);
                }
                return _shoesAdditionalInfo;
            }
        }
    
        public IContractRepository Contract
        {
            get
            {
                if (_contract == null)
                {
                    _contract = new ContractRepository(_context);
                }
                return _contract;
            }
        }
        public ICustomerOrderRepository CustomerOrder
        {
            get
            {
                if (_customerOrder == null)
                {
                    _customerOrder = new CustomerOrderRepository(_context);
                }
                return _customerOrder;
            }
        }
        public IOrderShoesInfoMapRepository OrderShoesInfoMap
        {
            get
            {
                if (_orderShoesInfoMap == null)
                {
                    _orderShoesInfoMap = new OrderShoesInfoMapRepository(_context);
                }
                return _orderShoesInfoMap;
            }
        }
    }
}
