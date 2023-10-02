using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ContactList.Interfaces;

public interface IMenuService // vad som kommer listas upp i menyn
{
    public void MainMenu();
    public void CreateContact();
    public void RemoveContact();
    public void ListContacts();
    public void EditContact();
    public void GetOneContact();
}
