using OuroborosEvents.MVVM.Models;
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
            RegisterBtn.Text = "Email already exist";
            createuser = false;
        }

        // Check if email is valid and non-disposable
        VerificationAPI deserializedResponse = await VerificationAPI.VerifyEmailAsync(currentemail);
        if (deserializedResponse != null)
        {
            if (deserializedResponse.IsDisposable is true)
            {
                RegisterBtn.Text = "This is a disposable Email.";
                createuser = false;
            }
            if (deserializedResponse.IsValid is false)
            {
                RegisterBtn.Text = "This is not a valid Email.";
                createuser = false;
            }
        }


        // Check if password 1 and 2 are the same
        if (RegPasswordCheck.Text == RegPassword.Text)
        {
            if (createuser)
            {
                // Create guest
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
            await DisplayAlert("Error", "Some details were wrong, or you have entered the same password twice.", "Ok");
        }
    }
}