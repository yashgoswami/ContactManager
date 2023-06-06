using ContactManager.Application.DTOs;

namespace ContactManager.Application.Contracts.Contact
{
    public interface IContactRepository : IAsyncGenericRepository<ContactManager.Domain.Entities.Contact>
    {
        Task<List<ContactManager.Domain.Entities.Contact>> GetAllContacts();

        Task<bool> AddContact(AddContactInput addContactInput);
        Task<bool> DeleteContact(int contactId);
        Task<bool> EditContact(EditContactInput editContactInput);

    }
}
