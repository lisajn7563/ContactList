using C__ContactList.Models;


namespace C__ContactList.Interfaces;

public interface IContactService // interfacet IContactService hantering av kontaktuppgifter
{
    public ContactPerson AddContact(ContactPerson contact); // Metod som används för att lägga till en ny kontakt (objekt)
    IEnumerable<ContactPerson> GetAllContacts(); // Metod för att hämta alla befintliga i  kontakter från istan < ContactPerson >

    public void UpdateContact(string email, ContactPerson editContact); // Metod som hämtar info från spec kontakt via email, uppdateras och den nya kontakten som ContactPerson 
    public void DeleteContact(string email); // Metod för att hämta och ta bort befintlig kontakt via email
    ContactPerson GetContactPerson(string email); // Metod för att hämta befintlig kontakt via mail
    
}
