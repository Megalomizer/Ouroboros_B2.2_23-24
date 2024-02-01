using OuroborosEvents.MVVM.Models;
using OuroborosEvents.Abstractions;
using System.Collections.Generic;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;

namespace OuroborosEvents.MVVM.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private async void RegisterBtn_Clicked(object sender, EventArgs e)
    {
        // Check if email already exists
        List<Guest> AllGuests = App.GuestRepo.GetEntities();
        string currentemail = RegEMail.Text;
        bool createuser = true;

        if (AllGuests.FirstOrDefault(g => g.Email == currentemail) != default(Guest))
        {
            await DisplayAlert("Error", "This Email is already registered.", "Ok");
            createuser = false;
        }

        // Check if email is valid and non-disposable
        VerificationAPI deserializedResponse = await VerificationAPI.VerifyEmailAsync(currentemail);
        if (deserializedResponse != null)
        {
            if (deserializedResponse.IsDisposable is true)
            {
                await DisplayAlert("Error", "You have entered a disposable Email Adress. Please enter your real Email.", "Ok");
                createuser = false;
            }
            if (deserializedResponse.IsValid is false)
            {
                await DisplayAlert("Error", "You have entered an invalid Email Adress.", "Ok");
                createuser = false;
            }
        }


        // Check if password 1 and 2 are the same
        if (RegPasswordCheck.Text == RegPassword.Text)
        {
            if (createuser)
            {
                // Create user
                Guest guest = new Guest();

                guest.FirstName = RegFirstName.Text;
                guest.LastName = RegLastName.Text;
                guest.Email = RegEMail.Text;
                guest.Password = RegPassword.Text;
                guest.PhoneNumber = Int32.Parse(RegPhone.Text);

                App.GuestRepo.SaveEntity(guest);
                await Navigation.PopAsync();
            }
        }
        else
        {
            await DisplayAlert("Error", "Something was left open, or you made a mistake in your password confirmation.", "Ok");
        }
    }
}