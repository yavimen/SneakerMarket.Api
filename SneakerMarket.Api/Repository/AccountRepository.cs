using Contracts;
using Microsoft.EntityFrameworkCore;
using SneakerMarket.Api;
using SneakerMarket.Api.Models;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationContext context):
            base(context){ }

        public void CreateAccount(Account account)
        {
            Create(account);
        }

        public void DeleteAccount(Account account)
        {
            Delete(account);
        }

        public async Task<Account?> GetAccountByIdAsync(Guid id)
        {
            return await FindByCondition(a => a.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<Account?> GetAccountByEmailWithDetailsAsync(string email)
        {
            return await FindByCondition(a => a.Email.Equals(email))
                .Include(a => a.Contacts)
                .Include(a => a.CustomerInfo)
                .FirstOrDefaultAsync();
        }

        public async Task<Account?> GetAccountByEmailAsync(string email)
        {
            return await FindByCondition(a => a.Email.Equals(email))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await FindAll()
                .OrderBy(a => a.Email)
                .ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAccountsWithDetailsAsync()
        {
            return await FindAll()
                .Include(a => a.Contacts)
                .OrderBy(a => a.Email)
                .ToListAsync();
        }

        public void UpdateAccount(Account account)
        {
            Update(account);
        }
    }
}
