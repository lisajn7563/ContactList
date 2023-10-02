using C__ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ContactList.Interfaces;

public interface IContactService
{
    public ContactPerson AddContact(ContactPerson contact);
    IEnumerable<ContactPerson> GetAllContacts();

    public void UpdateContact(string email, ContactPerson editContact);
    public void DeleteContact(string email);
    ContactPerson GetContactPerson(string email);
}
