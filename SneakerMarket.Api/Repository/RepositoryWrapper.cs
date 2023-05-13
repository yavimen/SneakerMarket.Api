using Contracts;
using SneakerMarket.Api;
using SneakerMarket.Api.Repository.Contracts;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        protected IAccountRepository? _account;
        protected IContactRepository? _contact;
        protected ICustomerInfoRepository? _customerInfo;
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
    }
}
