using C__ContactList.Models;
using System.Collections.ObjectModel;

namespace MauiContactList
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<ContactPerson> contactPerson = new ObservableCollection<ContactPerson>()
        {
            new ContactPerson{ FirstName = "test"},
            new ContactPerson { LastName = "test"}
        };
       

        public MainPage()
        {
            InitializeComponent();
            ContactList.ItemsSource = contactPerson;
        }

    }
}