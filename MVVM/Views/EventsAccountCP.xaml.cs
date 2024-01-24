

namespace OuroborosEvents.MVVM.Views;

public partial class EventsAccountCP : ContentPage
{
	public EventsAccountCP()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            //LOAD PHOTO
            FileResult photo = await MediaPicker.Default.PickPhotoAsync();
            if (photo != null)
            {
                //SAVE THE IMAGE
                AccountCPProfilePicture.Source = ImageSource.FromStream(() => photo.OpenReadAsync().Result);
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Oops", "Your device isn't supported", "Ok");
        }
        }
    }

