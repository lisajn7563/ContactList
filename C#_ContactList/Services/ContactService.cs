using C__ContactList.Interfaces;
using C__ContactList.Models;
using Newtonsoft.Json;


namespace C__ContactList.Services; 

public class ContactService : IContactService  // logiken ligger i servicen
{
    private List<ContactPerson> _contactList = new List<ContactPerson>(); //instans, privat lista som bara kan nås från andra i samma class,( en lista som skapar/lagra ContactPerson- objekt)
    
    public ContactService() // constructor
    {

        var items = GetAllContacts();
        if (items != null)
            foreach (var item in items)
                _contactList.Add(item);
        else
            _contactList = new List<ContactPerson>();
        // om filen eller listan är tom ska man kunna hämta den iallafall?? 

    }

    public ContactPerson AddContact(ContactPerson contact) // (metod) service till att lägga till kontakt
    {
        _contactList.Add(contact); // metod som lägger till en kontakt

        var json = JsonConvert.SerializeObject(_contactList); // metod som omvandlar kontaktlistan till en JSON sträng som innehåller kontaktobjekt
        FileService.SaveToFile(json);// sprara till fil

        return contact;
    }

    public void DeleteContact(string email)
    {
        _contactList = GetFile(); // hämtar från fil
        var contact = GetContactPerson(email); // hämtar en kontakt via mail
        if (contact != null)
            _contactList.Remove(contact); // raderar den hittade kontakten

        var json= JsonConvert.SerializeObject(_contactList);
        FileService.SaveToFile(json);//sparar mer till fil
    } // (metod) service till att ta bort kontakt

    public IEnumerable<ContactPerson> GetAllContacts() // gränssnitt för att visa hela listan
    {
        var file = FileService.ReadFromFile(); // hämtar från fil
        if (!string.IsNullOrEmpty(file))// om filen inte är null kommer den lista upp kontaktinfo
            _contactList = JsonConvert.DeserializeObject<List<ContactPerson>>(file)!;// konvertera objekt från jasondata 

        return _contactList.OrderByDescending(x => x.Id); // LINQ, för att sortera i listan baserat på ID
    } 

    public ContactPerson GetContactPerson(string email)
    {
        var _contact = GetFile(); // hämtar från fil

        var contact = _contactList.FirstOrDefault(x => x.Email == email); // sökningsmetod för att söka efter email (LINQ)
        if (contact != null)// om kontakten inte är null, kör nedan
        {
            return contact;
        }
        return null!;


    } // (metod) service till att hämta en kontakt via email

    public void UpdateContact(string email, ContactPerson editContact)
    {
        var _contact = GetFile(); // hämtar fil (från public List <contactPerson> GetFile) 

        var contact = GetContactPerson(email); // hämtar kontakt via mail

        if (contact != null) // om kontakten inte är null körs nedan
        {
            _contactList.Remove(contact); // tar bort
            _contactList.Add(editContact); // skriver över en uppdaterad kontakt
            var json = JsonConvert.SerializeObject(_contactList); // metod som omvandlar kontaktlistan till en JSON sträng som innehåller kontaktobjekt
            FileService.SaveToFile(json);// sparar ner till fil
        }    
    } //(metod) som hämtar kontakt med email och skriver över uppdaterad kontakt

    public List<ContactPerson> GetFile()
    {
        var file = FileService.ReadFromFile();
        if (!string.IsNullOrEmpty(file))
            return _contactList = JsonConvert.DeserializeObject<List<ContactPerson>>(file)!;
        return null!;
    } //(metod) service till att läsa från fil, alltså hämta från fil
}
