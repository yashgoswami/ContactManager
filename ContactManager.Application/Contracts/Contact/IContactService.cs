using ContactManager.Application.DTOs;

namespace ContactManager.Application.Contracts.Contact
{
    public interface IContactService
    {
        Task<AddContactOutput> AddContact(AddContactInput addContactInput);
        Task<List<ContactOutput>> GetAllContacts();
        Task<bool> EditContact(EditContactInput editContactInput);
        Task<bool> DeleteContact(int contactId);
    }
}
