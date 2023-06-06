using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.Domain.Entities;
using ContactManager.Application.Contracts.Contact;
using Dapper;
using ContactManager.Application.DTOs;

namespace ContactManager.Persistence.Repositories
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> AddContact(AddContactInput addContactInput)
        {
            string selectSQl = "SELECT top 1 Id from Contacts where FirstName = @fname and LastName = @lname and Email = @email and PhoneNumber = @phonenumber";

            string insertQuery = @"INSERT INTO [dbo].[Contact]([FirstName], [LastName], [PhoneNumber], [Email], [Status]) VALUES (@fname, @lname, @email, @phoneNumber, @status)";

            using SqlConnection conn = new SqlConnection(_connectionString);
            var contactId = (await conn.QueryAsync(selectSQl, new
            {
                fname = addContactInput.FirstName,
                lname = addContactInput.LastName,
                email = addContactInput.Email,
                phoneNumber = addContactInput.PhoneNumber,
            })).FirstOrDefault();

            if (contactId != null && contactId > 0)
            {
                return false;
            }
            
            // get the number of rows inserted for debugging purpose
            var insertedRow = await conn.ExecuteAsync(insertQuery, new
            {
                fname = addContactInput.FirstName,
                lname = addContactInput.LastName,
                email = addContactInput.Email,
                phoneNumber = addContactInput.PhoneNumber,
                status = addContactInput.Status,
            });

            return insertedRow > 0;
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            await DeleteAsync(contactId);                        
            return true;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return (await GetAllAsync()).ToList();
        }

        public async Task<bool> EditContact(EditContactInput editContactInput)
        {
            // [dbo].[Contact]([FirstName], [LastName], [PhoneNumber], [Email], [Status])
            var updateQuery = "UPDATE [dbo].[Contact] SET FirstName = @fname, LastName = @lname, Email = @email, PhoneNumber = @phoneNumber WHERE Id = @id";
            using SqlConnection conn = new SqlConnection(_connectionString);
            var updatedRows = await conn.ExecuteAsync(updateQuery, new
            {
                fname = editContactInput.FirstName,
                lname = editContactInput.LastName,
                email = editContactInput.Email,
                phoneNumber = editContactInput.PhoneNumber,
                status = editContactInput.Status,
                id = editContactInput.Id
            });

            return updatedRows > 0;

        }
    }
}
