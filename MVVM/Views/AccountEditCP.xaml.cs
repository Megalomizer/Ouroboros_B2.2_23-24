using OuroborosEvents.MVVM.Models;
using OuroborosEvents.MVVM.ViewModels;
using OuroborosEvents.Abstractions;

namespace OuroborosEvents.MVVM.Views;

public partial class AccountEditCP : ContentPage
{
    public YourAccountVM YourAccountVM { get; set; }

    
    public AccountEditCP()
	{
        BindingContext = new YourAccountVM();
		InitializeComponent();
	}

    private async void RegisterBtn_Clicked(object sender, EventArgs e)
    {
        string title = "You are about to change account information. Are you sure you want to change this information?";
        string cancel = "Cancel changes";
        string destruction = "Save Changes";
        string useraction = await DisplayActionSheet(title, cancel, destruction);

        if (useraction == destruction)
        {
            if (App.LoggedInUser.GetType() == typeof(Guest))
            {
                Guest uneditedUser = App.GuestRepo.GetEntity(App.LoggedInUser.Id);
                Guest newUser = new Guest()
                {
                    FirstName = RegFirstName.Text,
                    LastName = RegLastName.Text,
                    Email = RegEMail.Text,
                    PhoneNumber = Int32.Parse(RegPhone.Text),
                    LinkedIn = RegLinkedIn.Text,

                    EventEntries = uneditedUser.EventEntries,
                    Id = uneditedUser.Id,
                    Password = uneditedUser.Password
                };

                if (newUser.FirstName == null)
                    newUser.FirstName = uneditedUser.FirstName;
                if(newUser.LastName == null)
                    newUser.LastName = uneditedUser.LastName;
                if(newUser.Email == null)
                    newUser.Email = uneditedUser.Email;
                if(newUser.PhoneNumber == null)
                    newUser.PhoneNumber = uneditedUser.PhoneNumber;
                if(newUser.LinkedIn == null)
                    newUser.LinkedIn = uneditedUser.LinkedIn;

                App.LoggedInUser = newUser;
                App.GuestRepo.SaveEntity(newUser);
            }
            else if (App.LoggedInUser.GetType() == typeof(Organiser))
            {
                Organiser uneditedUser = App.OrganiserRepo.GetEntity(App.LoggedInUser.Id);
                Organiser newUser = new Organiser()
                {
                    FirstName = RegFirstName.Text,
                    LastName = RegLastName.Text,
                    Email = RegEMail.Text,
                    PhoneNumber = Int32.Parse(RegPhone.Text),
                    LinkedIn = RegLinkedIn.Text,

                    Events = uneditedUser.Events,
                    OrganisationName = uneditedUser.OrganisationName,
                    Id = uneditedUser.Id,
                    Password = uneditedUser.Password
                };

                if (newUser.FirstName == null)
                    newUser.FirstName = uneditedUser.FirstName;
                if (newUser.LastName == null)
                    newUser.LastName = uneditedUser.LastName;
                if (newUser.Email == null)
                    newUser.Email = uneditedUser.Email;
                if (newUser.PhoneNumber == null)
                    newUser.PhoneNumber = uneditedUser.PhoneNumber;
                if (newUser.LinkedIn == null)
                    newUser.LinkedIn = uneditedUser.LinkedIn;

                App.LoggedInUser = newUser;
                App.OrganiserRepo.SaveEntity(newUser);
            }
            else if (App.LoggedInUser.GetType() == typeof(Exhibitor))
            {            
                Exhibitor uneditedUser = App.ExhibitorRepo.GetEntity(App.LoggedInUser.Id);
                Exhibitor newUser = new Exhibitor()
                {
                    FirstName = RegFirstName.Text,
                    LastName = RegLastName.Text,
                    Email = RegEMail.Text,
                    PhoneNumber = Int32.Parse(RegPhone.Text),
                    LinkedIn = RegLinkedIn.Text,

                    ExhibitId = uneditedUser.ExhibitId,
                    Id = uneditedUser.Id,
                    Password = uneditedUser.Password
                };

                if (newUser.FirstName == null)
                    newUser.FirstName = uneditedUser.FirstName;
                if (newUser.LastName == null)
                    newUser.LastName = uneditedUser.LastName;
                if (newUser.Email == null)
                    newUser.Email = uneditedUser.Email;
                if (newUser.PhoneNumber == null)
                    newUser.PhoneNumber = uneditedUser.PhoneNumber;
                if (newUser.LinkedIn == null)
                    newUser.LinkedIn = uneditedUser.LinkedIn;

                App.LoggedInUser = newUser;
                App.ExhibitorRepo.SaveEntity(newUser);
            }


            await Navigation.PopAsync();
        }
    }
}