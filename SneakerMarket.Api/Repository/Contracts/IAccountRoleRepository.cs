using SneakerMarket.Api.Models;

namespace SneakerMarket.Api.Repository.Contracts
{
    public interface IAccountRoleRepository
    {
        Task<IEnumerable<AccountRole>> GetAllAccountRolesAsync();

        Task<AccountRole?> GetAccountRoleByIdAsync(Guid id);
    }
}
