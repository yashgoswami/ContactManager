using ContactManager.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Application.Contracts.Contact
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _uow;
        public ContactService(IUnitOfWork uow)
        {
            _uow = uow;
        }       
        public async Task<AddContactOutput> AddContact(AddContactInput addContactInput)
        {
            var result = await _uow.ContactRepository.AddContact(addContactInput);
            var errors = new List<String>();
            // here handle any extra error while creation of contact

            string message = result ? $"Contact added for {addContactInput.FirstName} {addContactInput.LastName}" :
                                      $"Contact could not be added for {addContactInput.FirstName} {addContactInput.LastName}";
            return new AddContactOutput(result, errors, message);
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            var result = await _uow.ContactRepository.DeleteContact(contactId);
            return result;
        }

        public async Task<bool> EditContact(EditContactInput editContactInput)
        {
            var result = await _uow.ContactRepository.EditContact(editContactInput);
            return result;
        }

        public async Task<List<ContactOutput>> GetAllContacts()
        {            
            var result = await _uow.ContactRepository.GetAllContacts();
            if (result == null)
                return new List<ContactOutput>();

            List<ContactOutput> contactOutput = result.Select(source =>
                new ContactOutput(source.Id, source.FirstName, source.LastName, source.Email, source.PhoneNumber, source.Status)).ToList();
            return contactOutput;
        }
    }
}
