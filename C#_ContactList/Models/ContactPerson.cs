using C__ContactList.Interfaces;


namespace C__ContactList.Models;

public class ContactPerson : IContactPerson // klassen ContactPerson som implentanterar interface IContactPerson

{
    public Guid Id { get; set; } = Guid.NewGuid(); // unikt id när en ContactPesrson- instans skapas
    public string? FirstName { get; set; } // egenskap för att represtentera förnamn (?) visar att de kan vara null
    public string? LastName { get; set; } 
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public Address? Address { get; set; } // egenskap som representerar adress, Address innenhåller allt i Klassen Adress

} /* denna klass används för att skapa objekt som representerar kontaktionfomation för personer
     Eftersom IContactPerson är implementerat måste de erbjudas implementationer för alla de egenskaper
     som finns i gränssnittet*/

