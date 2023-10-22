using C__ContactList.Models;


namespace C__ContactList.Interfaces;

public interface IContactPerson /* gränssnitt av en kontakt och metoder som 
                                   en klass som implementerar gränssnittet måste tillhanshålla, ett typ av krav */
{
    public string? FirstName { get; set; } // get (hämta/läsa), set(skriva) för att läsa och skriva egenskaper
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public Address? Address { get; set; }
}
 