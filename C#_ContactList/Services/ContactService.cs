using C__ContactList.Interfaces;
using C__ContactList.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace C__ContactList.Services
{
    public class ContactService : IContactService
    {
        private List<ContactPerson> _contactList = new List<ContactPerson>();
        private List<IContactPerson> iContactList = new List<IContactPerson>();
        public ContactPerson AddContact(ContactPerson contact)
        {
            _contactList.Add(contact);

            var json = JsonConvert.SerializeObject(_contactList);
            FileService.SaveToFile(json);

            return contact;
        }

        public void DeleteContact(string email)
        {
            _contactList = GetFile();
            var contact = GetContactPerson(email);
            if (contact != null)
                _contactList.Remove(contact);

            var json= JsonConvert.SerializeObject(_contactList);
            FileService.SaveToFile(json);
        }

        public IEnumerable<ContactPerson> GetAllContacts()
        {
            var file = FileService.ReadFromFile();
            if (!string.IsNullOrEmpty(file))
                _contactList = JsonConvert.DeserializeObject<List<ContactPerson>>(file)!;

            return _contactList.OrderByDescending(x => x.Id);
        }

        public ContactPerson GetContactPerson(string email)
        {
            var _contact = GetFile();

            var contact = _contactList.FirstOrDefault(x => x.Email == email);
            if (contact != null)
            {
                return contact;
            }
            return null!;


        }

        public void UpdateContact(string email, ContactPerson editContact)
        {
            var _contact = GetFile();

            var contact = GetContactPerson(email);

            if (contact != null)
            {
                _contactList.Remove(contact);
                _contactList.Add(editContact);
                var json = JsonConvert.SerializeObject(_contactList);
                FileService.SaveToFile(json);
            }    
        }

        public List<ContactPerson> GetFile()
        {
            var file = FileService.ReadFromFile();
            if (!string.IsNullOrEmpty(file))
                return _contactList = JsonConvert.DeserializeObject<List<ContactPerson>>(file)!;
            return null!;
        }
    }
}
