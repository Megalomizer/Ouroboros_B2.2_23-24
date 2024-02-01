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

    private void RegisterBtn_Clicked(object sender, EventArgs e)
    {

    }

    private async void DeleteBtn_Clicked(object sender, EventArgs e)
    { 
        // Action sheet to confirm account deletion
        string cancel = "Cancel";
        string destruction = "Delete account";
        string useraction = await DisplayActionSheet("Are you sure you want to permanently delete your account?", cancel, destruction);

        // Delete account
        if (useraction == destruction)
        {


            // this just logs out
            App.LoggedInUser = null;
            SecureStorage.Remove("Username");
            SecureStorage.Remove("Password");
            SecureStorage.Remove("Type");
            await Navigation.PopToRootAsync();
        }
    }
}