using ContactManager.Application.Contracts;
using ContactManager.Application.Contracts.Contact;
using ContactManager.Application.DTOs;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : BaseController<ContactsController>
    {
        protected readonly IContactService _contactService;
        public ContactsController(IContactService contactService, ILogger<ContactsController> logger) : base(logger)
        {
            _contactService = contactService;
        }

        // GET api/contacts
        [HttpGet]
        public async Task<ActionResult<IList<ContactOutput>>> GetAllContacts()
        {
            var contacts = await _contactService.GetAllContacts();
            return Ok(contacts);
        }

        // POST api/contacts/create
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ResponseMessage>> AddContact(AddContactInput addContactInput)
        {
            var response = await _contactService.AddContact(addContactInput);
            return Ok(response);
        }

        // PUT api/contacts/edit/{contactId}
        [HttpPut("{contactId}")]
        public async Task<ActionResult<ResponseMessage>> EditContact(int contactId, EditContactInput editContactInput)
        {
            var isUpdated = await _contactService.EditContact(editContactInput);
            return Ok(isUpdated);
        }

        // Delete api/contacts/{contactId}
        [HttpDelete("{contactId}")]
        public async Task<ActionResult<bool>> DeleteContact(int contactId)
        {
            var isDeleted = await _contactService.DeleteContact(contactId);
            return Ok(isDeleted);
        }
    }
}
