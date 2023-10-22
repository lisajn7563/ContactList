

namespace C__ContactList.Models;

public class Address /*Klass: En klass är en mall
                       som definierar hur ett objekt ska skapas.
                       Det innehåller medlemsvariabler och metoder 
                       som beskriver objektets egenskaper och beteende.*/
{
    public string? StreetName { get; set; }
    public string? ZipCode { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }

    public string? FullAddress => $"{StreetName}, {ZipCode}, {City}, {Country}";
}   
    


