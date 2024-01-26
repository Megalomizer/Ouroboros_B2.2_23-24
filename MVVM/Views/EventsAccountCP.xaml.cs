namespace OuroborosEvents.MVVM.Views;
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
            // LOAD PHOTO
            FileResult photo = await MediaPicker.Default.PickPhotoAsync();
            if (photo != null)
            {
                // SAVE THE IMAGE
                string photoPath = SaveImage(photo);
                Preferences.Set(PhotoPathKey, photoPath);
                AccountCPProfilePicture.Source = ImageSource.FromFile(photoPath);
            }
        }
        else
        {
            //IF something goes wrong. Not very likely to happen doe
            await Shell.Current.DisplayAlert("Oops", "Your device isn't supported", "Ok");
        }
    }

    private string SaveImage(FileResult photo)
    {
        // You can customize the directory and file name based on your requirements
        string directory = FileSystem.AppDataDirectory;
        string fileName = "profile_picture.jpg";
        string filePath = Path.Combine(directory, fileName);

        using (Stream stream = photo.OpenReadAsync().Result)
        {
            using (FileStream fileStream = File.Open(filePath, FileMode.Create))
            {
                stream.CopyTo(fileStream);
            }
        }

        return filePath;
    }
}
