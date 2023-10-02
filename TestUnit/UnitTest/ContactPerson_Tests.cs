using C__ContactList.Interfaces;
using C__ContactList.Models;
using C__ContactList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Tests.UnitTest;

public class ContactPerson_Tests
{
    [Fact]
    public void CreateContact_Should_CreateNewContactAndAddContactToList_ReturnCreatedContact()
    {
        //Arrange
        ContactPerson contact = new ContactPerson();
        contact.FirstName = "Lisa";
        contact.LastName = "Johansson";
        contact.Email = string.Empty;
        contact.PhoneNumber = string.Empty;
        contact.Address = new Address();

        IContactService contactService = new ContactService();


        //Act
        ContactPerson result = contactService.AddContact(contact);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<ContactPerson>(result);
    }
}
