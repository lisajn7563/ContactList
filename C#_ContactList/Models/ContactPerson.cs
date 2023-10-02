using C__ContactList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ContactList.Models;

public class ContactPerson : IContactPerson

{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? FirstName { get; set; } 
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public Address? Address { get; set; }

}

