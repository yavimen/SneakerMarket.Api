using Contracts;
using Microsoft.EntityFrameworkCore;
using SneakerMarket.Api;
using SneakerMarket.Api.Models;
using SneakerMarket.Api.Repository.Contracts;

namespace Repository
{
    public class AccountRoleRepository : RepositoryBase<AccountRole>, IAccountRoleRepository
    {
        public AccountRoleRepository(ApplicationContext context):
            base(context){ }

        public async Task<AccountRole?> GetAccountRoleByIdAsync(Guid id)
        {
            return await FindByCondition(a => a.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AccountRole>> GetAllAccountRolesAsync()
        {
            return await FindAll()
                .OrderBy(a => a.Role)
                .ToListAsync();
        }
    }
}
