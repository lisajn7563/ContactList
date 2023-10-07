using C__ContactList.Interfaces;
using C__ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ContactList.Services;

public class MenuService : IMenuService
{
    private readonly ContactService _contactService = new ContactService(); // skapar en ny instant av ContactService klassen som läggs i _contactService
    /*Objekt (instanser): Ett objekt är en konkret 
    förekomst av en klass. Det är en individuell
    enhet som har sina egna unika egenskaper
    (medlemsvariabler) och kan utföra handlingar 
    (metoder) enligt beskrivningen som ges av klassen */
    public void CreateContact()
    {
        var contact = new ContactPerson();

        // skapar en ny instans av ContactPerson

        Console.Clear();
        Console.WriteLine("LÄGG TILL EN KONTAKT");
        Console.WriteLine("....................");
        Console.WriteLine();
        Console.WriteLine("Förnamn: ");
        contact.FirstName = Console.ReadLine();
        Console.WriteLine("Efternamn: ");
        contact.LastName = Console.ReadLine();
        Console.WriteLine("E-post: ");
        contact.Email = Console.ReadLine()!.Trim().ToLower();
        Console.WriteLine("Telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine();

        var contactAddress = new Address();

        //skapa ny instans av address klassen


        Console.WriteLine("Gatuadress: ");
        contactAddress.StreetName = Console.ReadLine();
        Console.WriteLine("Postkod: ");
        contactAddress.ZipCode = Console.ReadLine();
        Console.WriteLine("Stad: ");
        contactAddress.City = Console.ReadLine();
        Console.WriteLine("Land: ");
        contactAddress.Country = Console.ReadLine();

        //assignar contactadress till adressen för en contactperson
        contact.Address = contactAddress;

        //lägger till kontakten i en lista av typen contactperson
        _contactService.AddContact(contact);

        Console.Clear();
        Console.WriteLine("*Kontaktpersonen är nu tillagd*");
        Console.ReadKey();
        MainMenu();

    } // skapar en kontakt

    public void EditContact()
    {
        Console.Clear();
        Console.WriteLine("UPPDATERA EN KONTAKT");
        Console.WriteLine("....................");
        Console.Write("Ange e-post: ");
        var email = Console.ReadLine()!.Trim().ToLower();
        try
        {
            var contact = _contactService.GetContactPerson(email!); // hämtar kontakten via mail
            

            if (contact != null) // om kontakten inte är null skrivs de nedan ut
            {

                Console.WriteLine("KONTAKTEN SOM HITTADES");
                Console.WriteLine("......................");
                Console.WriteLine($"Namn: {contact.FirstName}{contact.LastName}");
                Console.WriteLine($"Epost: {contact.Email}");
                Console.WriteLine($"Telefonummer: {contact.PhoneNumber}");
                Console.WriteLine($"Adress: {contact?.Address?.FullAddress}");

                Console.WriteLine();
                Console.WriteLine("Vill du ändra denna Kontakt? (Ja/Nej):");
                var response = Console.ReadLine();
                Console.Clear();

                /* om response = ja är de true, 
                 annars retunera false (då kommer inga ändriga göras)
                 .Equals("Ja", StringComparison.OrdinalIgnoreCase)
                 jämför den trimmade textsträngen response med texten "Ja"
                 oavsett versaler eller gemener (stor- eller småbokstäver).
                 StringComparison.OrdinalIgnoreCase är en inställning
                 som ignorerar bokstavsstorleken vid jämförelse.*/

                if (response?.Trim().Equals("Ja", StringComparison.OrdinalIgnoreCase) == true) 
                {
                    Console.Write("Nytt förnamn: ");
                    var newFirstName = Console.ReadLine();
                    contact.FirstName = newFirstName!;

                    Console.Write("Nytt Efternamn: ");
                    var newLastName = Console.ReadLine();
                    contact.LastName = newLastName!;

                    Console.Write("Ny E-post: ");
                    var newEmail = Console.ReadLine();
                    contact.Email = newEmail!;

                    Console.Write("Nytt telefonummer: ");
                    var newPhoneNumber = Console.ReadLine();
                    contact.PhoneNumber = newPhoneNumber!;

                   
                    
                    Address newAddress = new Address(); //skapa ny instans av new address klassen

                    Console.Write("Gatuadress: ");
                    newAddress.StreetName = Console.ReadLine()!.Trim();
                    Console.Write("Postkod: ");
                    newAddress.ZipCode = Console.ReadLine()!.Trim();
                    Console.Write("Stad: ");
                    newAddress.City = Console.ReadLine()!.Trim();
                    Console.Write("Land: ");
                    newAddress.Country = Console.ReadLine()!.Trim();


                    contact.Address = newAddress!; //assignar contact.adress till nya adress

                    _contactService.UpdateContact(email, contact);  // anrop till metoden som tillhör objekt av ContactService

                    Console.WriteLine("*Kontaktpersonen är nu uppdaterad*");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("~Ingen ändrig gjordes~"); // om svaret inte är ja skrivs detta ut
                    Console.ReadLine();
                }
            }
        }
        catch { }
        Console.Clear();
        MainMenu();
    } // hämtning via mail, uppdaterar eller redigning av en kontakt

    public void GetOneContact()
    {
        Console.Clear();
        Console.WriteLine("KONTAKTPERSON");
        Console.WriteLine(".............");
        Console.WriteLine();
        Console.Write("Ange e-post: ");
        var email = Console.ReadLine();
        try
        {

            var contact = _contactService.GetContactPerson(email!); // hämtning
            if (contact != null) // om kontakten inte är null skrivs nedan ut
            {

                Console.Clear();
                Console.WriteLine("KONTAKTPERSON");
                Console.WriteLine(".............");
                Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"E-post: {contact.Email}");
                Console.WriteLine($"Telefonummer: {contact.PhoneNumber}");
                Console.WriteLine($"Adress: {contact?.Address?.FullAddress}");

                Console.ReadKey();
                MainMenu(); // går tillbaka till menyn
            }
            else // om kontatken inte finns skrivs nedan 
            {
                Console.WriteLine("~Kontaktpersonen kunde inte hittas~"); 
            }
        }


        catch { }
        Console.ReadKey();
        MainMenu();

    } // hämtar en kontakt via mail

    public void ListContacts()
    {
        Console.Clear();
        Console.WriteLine("ALLA I KONTAKTLISTAN");
        Console.WriteLine("....................");
        Console.WriteLine();

        var contactList = _contactService.GetAllContacts(); // hämtar en lista med från obejktet _contactService
        if (contactList.Count() > 0) // kontrollerar att listan inte är tom, om listan inte är tom listas listan 
        {

            foreach (var contact in _contactService.GetAllContacts()) // hämtar alla kontakter i _contactService
                if (contact != null) // om listan inte är null skrivs de befintliga kontanker ut

                {
                    Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"E-post: {contact.Email}");
                    Console.WriteLine($"Telefonummer: {contact.PhoneNumber}");
                    Console.WriteLine($"Adress: {contact?.Address?.FullAddress}");
                    Console.WriteLine();

                }

        }
        else
        {
            Console.WriteLine("~Det finns ingen kontakt i kontaktlistan~"); // om den inte finns några kontakter i listan

        }

        Console.ReadKey();
        MainMenu();
    } // hämtar alla kontakter

    public void MainMenu()
    {
        try 
        {
            Console.Clear();
            Console.WriteLine("KONTAKTLISTA");
            Console.WriteLine(".............");
            Console.WriteLine();
            Console.WriteLine("Välj något av alternativen nedan");
            Console.WriteLine();
            Console.WriteLine("1. Lägg till en kontakt");
            Console.WriteLine("2. Radera en kontakt");
            Console.WriteLine("3. Hämta en kontakt");
            Console.WriteLine("4. Uppdatera kontakt");
            Console.WriteLine("5. Visa alla kontakter");
            Console.WriteLine("6. Avsluta");
            
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 6)// felhantering, ifall man skriver in en sträng i konsolen, och inte väljer en int från 1 till 6
            {
                Console.Write("Något gick fel, välj ett nummer mellan 1-6: "); 
                
            }


            switch (option)
            {
                case 1:
                    CreateContact();
                    break;
                case 2:
                    RemoveContact();
                    break;
                case 3:
                    GetOneContact();
                    break;
                case 4:
                    EditContact();
                    break;
                case 5:
                    ListContacts();
                    break;
                case 6:
                    Environment.Exit(6);
                    break;
                default:
                    break;

            }
        }
        catch
        { }

    } // huvudmeyn och alternativ ( switch ) även ifall man ej väljer en int, så felhantering

    public void RemoveContact()
    {
        Console.Clear();
        Console.WriteLine("RADERA EN KONTAKT");
        Console.WriteLine("..............");
        Console.WriteLine();
        Console.Write("Ange e-post: ");
        var email = Console.ReadLine()!.Trim();



        try
        {
            var contact = _contactService.GetContactPerson(email!); // anropen metod getcontactperson via mail

            if (contact != null) // om den inte är null skrivs nedan ur
            {

                Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"E-post: {contact.Email}");
                Console.WriteLine($"Telefonummer: {contact.PhoneNumber}");
                Console.WriteLine($"Adress: {contact?.Address?.FullAddress}");

                Console.WriteLine();
                Console.WriteLine("Vill du radera denna Kontakt? (Ja/Nej):");
                var response = Console.ReadLine();
                Console.Clear();

                if (response?.Trim().Equals("Ja", StringComparison.OrdinalIgnoreCase) == true)
                {
                    _contactService.DeleteContact(email!);

                    Console.Clear();
                    Console.WriteLine("*Kontaktpersonen är nu raderad*");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("~Kontaktpersonen finns kvar i kontaktlistan~");
                }

            Console.ReadKey();
                MainMenu();
            }
            else
            {
                Console.WriteLine("~Kontaktpersonen kunde inte hittas~");
            }
        }
        catch { }
        Console.ReadKey();
        MainMenu();
    } // tar bort kontakt via mail

}
