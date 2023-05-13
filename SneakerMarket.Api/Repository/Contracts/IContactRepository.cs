using SneakerMarket.Api.Models;

namespace SneakerMarket.Api.Repository.Contracts
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();

        Task<Contact?> GetContactByIdAsync(Guid id);

        Task<Contact?> GetContactByAccountIdAsync(Guid id);

        void CreateContact(Contact contact);

        void UpdateContact(Contact contact);

        void DeleteContact(Contact contact);
    }
}
