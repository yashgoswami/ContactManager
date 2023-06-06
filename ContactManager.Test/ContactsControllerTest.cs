using Xunit;
using FluentAssertions;
using Moq;
using ContactManager.API.Controllers;
using ContactManager.Application.Contracts.Contact;
using Microsoft.Extensions.Logging;
using ContactManager.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Test
{
    public class ContactsControllerTest
    {
        private readonly Mock<IContactService> mockContactService;
        private readonly ContactsController contactsController;
        private readonly List<ContactOutput> mockContactsOutput;
        private readonly AddContactOutput mockAddContactOutput;

        public ContactsControllerTest()
        {
            mockContactService = new Mock<IContactService>();
            contactsController = new(mockContactService.Object, new Mock<ILogger<ContactsController>>().Object);
            mockContactsOutput = new List<ContactOutput>();
            mockAddContactOutput = new AddContactOutput(true, new List<string>(), null);
        }

        [Fact]
        public async Task GetAllContactsReturnsValidData()
        {
            //Arrange
            mockContactService.Setup(x => x.GetAllContacts()).Returns(Task.FromResult(mockContactsOutput));

            //Act
            ActionResult<IList<ContactOutput>> result = await contactsController.GetAllContacts();
            OkObjectResult okResult = result.Result as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
            okResult.Value.Should().Be(mockContactsOutput);
        }

        [Fact]
        public async Task AddContactReturnsValidData()
        {
            //Arrange
            mockContactService.Setup(x => x.AddContact(It.IsAny<AddContactInput>())).Returns(Task.FromResult(mockAddContactOutput));

            //Act
            var input = new AddContactInput
            {
                FirstName = "Test",
            };

            var result = await contactsController.AddContact(input);
            OkObjectResult okResult = result.Result as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
            okResult.Value.Should().Be(mockAddContactOutput);
        }

        [Fact]
        public async Task EditContactReturnsValidData()
        {
            //Arrange
            mockContactService.Setup(x => x.EditContact(It.IsAny<EditContactInput>())).Returns(Task.FromResult(true));

            //Act
            var input = new EditContactInput(1, "Fname", "Lname", "Email", "90101000", "Active");

            var result = await contactsController.EditContact(1, input);
            OkObjectResult okResult = result.Result as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
            okResult.Value.Should().Be(true);
        }

        [Fact]
        public async Task DeleteContactReturnsValidData()
        {
            //Arrange
            mockContactService.Setup(x => x.DeleteContact(It.IsAny<int>())).Returns(Task.FromResult(true));

            //Act
            var result = await contactsController.DeleteContact(1);
            OkObjectResult okResult = result.Result as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
            okResult.Value.Should().Be(true);
        }
    }
}