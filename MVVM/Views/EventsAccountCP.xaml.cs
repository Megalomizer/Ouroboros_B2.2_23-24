namespace OuroborosEvents.MVVM.Views;

using Camera.MAUI;
using Newtonsoft.Json;
using OuroborosEvents.MVVM.Models;
using OuroborosEvents.MVVM.ViewModels;

public partial class EventsAccountCP : ContentPage
{
    private const string PhotoPathKey = "SelectedPhotoPath";

    public EventsAccountCP()
    {
        InitializeComponent();
        BindingContext = new YourAccountVM();

        // On startup, check if a photo path is stored in preferences and load it
        if (Preferences.ContainsKey(PhotoPathKey))
        {
            string photoPath = Preferences.Get(PhotoPathKey, string.Empty);
            AccountCPProfilePicture.Source = ImageSource.FromFile(photoPath);
        }
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            // LOAD PHOTO. everything is saved in cache in terms of pfp, so no keeping a pfp when app is delete/cache is emptied
            FileResult photo = await MediaPicker.Default.PickPhotoAsync();
            if (photo != null)
            {
                // SAVE THE IMAGE
                string photoPath = await SaveImage(photo);
                Preferences.Set(PhotoPathKey, photoPath);
                AccountCPProfilePicture.Source = ImageSource.FromFile(photoPath);
            }
        }
        else
        {
            // IF something goes wrong. Not very likely to happen though
            await Shell.Current.DisplayAlert("Oops", "Your device isn't supported", "Ok");
        }
    }

    private async Task<string?> SaveImage(FileResult photo)
    {
        // Generate a unique file name using a Guid
        string fileName = Guid.NewGuid().ToString("N") + ".jpg";
        string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

        using (Stream stream = await photo.OpenReadAsync())
        {
            using (FileStream fileStream = File.Open(filePath, FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        return filePath;
    }

    private async void LogoutUser(object sender, EventArgs e)
    {
        string cancel = "Cancel";
        string destruction = "Log out";
        string useraction = await DisplayActionSheet("Are you sure you want to log out?", cancel, destruction);

        if(useraction == destruction)
        {
            App.LoggedInUser = null;
            SecureStorage.Remove("Username");
            SecureStorage.Remove("Password");
            SecureStorage.Remove("Type");
            await Navigation.PopToRootAsync();
        }
    }

    private async void QR_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EventsQRCameraViewCP());
    }

    private async void EditAccountButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccountEditCP());
    }

    private async void ShowContactInfoQRBtn_Clicked(object sender, EventArgs e)
    {
        if (App.LoggedInUser == null)
            return;

        User activeUser = App.LoggedInUser;
        User contactSharing = new User()
        {
            FirstName = activeUser.FirstName,
            LastName = activeUser.LastName,
            Email = activeUser.Email,
            PhoneNumber = activeUser.PhoneNumber,
            LinkedIn = activeUser.LinkedIn
        };

        EventTicketQRVM vm = new EventTicketQRVM(contactSharing);

        await Navigation.PushAsync(new ContactInfoQRCodeCP() { BindingContext = vm });
    }

    private async void DeleteAccountButton_Clicked(object sender, EventArgs e)
    {
        string cancel = "Cancel";
        string destruction = "Delete account";
        string useraction = await DisplayActionSheet("You are about to delete your account along with all its information.\nThis action is not reversable!\nAre you sure you want to delete this account?", cancel, destruction);

        if(useraction == destruction)
        {
            User user = App.LoggedInUser;
            if(user.GetType() == typeof(Guest))
            {
                user = App.GuestRepo.GetEntity(user.Id);
                if (user != null)
                    App.GuestRepo.DeleteEntity((Guest)user);
            }
            else if(user.GetType() == typeof(Organiser))
            {
                user = App.OrganiserRepo.GetEntity(user.Id);
                if(user != null)
                    App.OrganiserRepo.DeleteEntity((Organiser)user);
            }
            else if(user.GetType() == typeof(Exhibitor))
            {
                user = App.ExhibitorRepo.GetEntity(user.Id);
                if(user != null)
                    App.ExhibitorRepo.DeleteEntity((Exhibitor)user);
            }

            App.LoggedInUser = null;
            SecureStorage.Remove("Username");
            SecureStorage.Remove("Password");
            SecureStorage.Remove("Type");
            await Navigation.PopToRootAsync();
        }
    }
}

