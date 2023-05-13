using Microsoft.EntityFrameworkCore;
using SneakerMarket.Api;
using SneakerMarket.Api.Models;
using SneakerMarket.Api.Repository.Contracts;

namespace Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationContext context):
            base(context){ }

        public void CreateContact(Contact contact)
        {
            Create(contact);
        }

        public void DeleteContact(Contact contact)
        {
            Delete(contact);
        }

        public async Task<Contact?> GetContactByIdAsync(Guid id)
        {
            return await FindByCondition(a => a.Id.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<Contact?> GetContactByAccountIdAsync(Guid id)
        {
            return await FindByCondition(a => a.AccountId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await FindAll()
                .OrderBy(a => a.Surname)
                .ToListAsync();
        }

        public void UpdateContact(Contact contact)
        {
            Update(contact);
        }
    }
}
