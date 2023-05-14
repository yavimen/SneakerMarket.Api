using SneakerMarket.Api.Models;

namespace Contracts
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();

        Task<Account?> GetAccountByEmailWithDetailsAsync(string email);

        Task<Account?> GetAccountByIdAsync(Guid id);

        Task<Account?> GetAccountByEmailAsync(string email);

        void CreateAccount(Account account);

        void UpdateAccount(Account account);

        void DeleteAccount(Account account);
    }
}
