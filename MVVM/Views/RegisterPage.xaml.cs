using OuroborosEvents.MVVM.Models;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace OuroborosEvents.MVVM.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private void RegisterBtn_Clicked(object sender, EventArgs e)
    {
        // Check if email already exists
        List<Guest> AllGuests = App.GuestRepo.GetEntities();
        string currentemail = RegEMail.Text;
        bool keepgoing = true;

        if (AllGuests.FirstOrDefault(g => g.Email == currentemail) != default(Guest))
        {
            RegisterBtn.Text = "Email already exists.";
            keepgoing = false;
        }

        // Check if password 1 and 2 are the same
        if (RegPasswordCheck.Text == RegPassword.Text)
            if (keepgoing)
            {
                // Create guest
                Guest guest = new Guest();

                guest.FirstName = RegFirstName.Text;
                guest.LastName = RegLastName.Text;
                guest.Email = RegEMail.Text;
                guest.Password = RegPassword.Text;
                guest.PhoneNumber = 0623596545;
            
                App.GuestRepo.SaveEntity(guest);
                RegisterBtn.Text = "Success.";
            }
        else
        {
            RegisterBtn.Text = "Some details were wrong, or you have entered the same password twice.";
        }
    }
}