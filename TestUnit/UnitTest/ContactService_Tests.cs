using C__ContactList.Interfaces;
using C__ContactList.Models;
using C__ContactList.Services;
using Moq;

namespace ContactList.Tests.UnitTest;

public class ContactService_Tests // integrationstest 
{
    [Fact]
    public void CreateContact_Should_CreateNewContactAndAddContactToList_ReturnCreatedContact() // beskrivning av vad som ska testas
    {
        //Arrange - detta är en hårdkodad person som finns för att testa så en kontakt läggs till i listan
        ContactPerson contact = new ContactPerson();
        contact.FirstName = "TestLisa";
        contact.LastName = "TestJohansson";
        contact.Email = "testlisa.jn@hotmail.com";
        contact.PhoneNumber = "test0702139914";
        contact.Address = new Address();

        IContactService contactService = new ContactService(); // instanserar gränssnitt till ny ContaactService


        //Act - Resultatet ska bli att detta "test" kontakt läggs till i listan
        ContactPerson result = contactService.AddContact(contact);

        //Assert
        Assert.NotNull(result); // om kontantlistan inte är null är resultatet korrekt
        Assert.IsType<ContactPerson>(result); // om läggs till i listan är resultatet korrekt
    }

}