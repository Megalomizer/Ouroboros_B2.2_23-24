using Camera.MAUI;
using Plugin.LocalNotification;
using System.Text.Json;
using System.IO;
using Plugin.LocalNotification.AndroidOption;
using OuroborosEvents.MVVM.Models;
using Plugin.LocalNotification.EventArgs;

namespace OuroborosEvents.MVVM.Views;

public partial class EventsQRCameraViewCP : ContentPage
{
	public EventsQRCameraViewCP()
	{
		InitializeComponent();
        LocalNotificationCenter.Current.NotificationActionTapped +=
            Current_NotificationActionTapped;
	}

    //This doesn't work btw lmao. I should find out why.
    public void Current_NotificationActionTapped(NotificationActionEventArgs e)
    {
        if (e.IsTapped) 
        {
            MainThread.BeginInvokeOnMainThread(async() =>
            {
                await Navigation.PushAsync(new EventsDiscoverCP());
            });
            
        }
    }

    
    
    private void QRCodeView_CamerasLoaded(object sender, EventArgs e)
    {
        if (QRCodeView.Cameras.Count > 0) 
        {
            QRCodeView.Camera = QRCodeView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                
                await QRCodeView.StopCameraAsync();
                await QRCodeView.StartCameraAsync();
                QRCodeView.BarCodeOptions = new()
                {
                    TryHarder = true
                };
            });
        }
    }

    public async void QRCodeView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            string contactInfo = $"{args.Result[0].BarcodeFormat}:{args.Result[0].Text}";
            contactInfo = contactInfo.Remove(0, 8);

            User contactShared = JsonSerializer.Deserialize<User>(contactInfo);

            if (contactShared == null)
                return;

            if (contactShared.FirstName == null)
                contactShared.FirstName = "Unkown";
            if (contactShared.LastName == null)
                contactShared.LastName = "Unkown";
            if (contactShared.Email == null)
                contactShared.Email = "Unkown";
            if (contactShared.LinkedIn == null)
                contactShared.LinkedIn = "Unkown";

            string description = $"Name: {contactShared.FirstName} {contactShared.LastName}\n" 
                                 + $"Email: {contactShared.Email}\n"
                                 + $"Phonenumber: {contactShared.PhoneNumber}\n"
                                 + $"LinkedIn: {contactShared.LinkedIn}\n";

            var Test = new NotificationRequest
            {
                NotificationId = 50,
                Title = $"You have succesfully scanned this QR code!",
                Subtitle = "Zuyd Events",
                Description = description,  
                BadgeNumber = 1,
            };

            LocalNotificationCenter.Current.Show(Test);

            await Navigation.PopAsync();
        });
    }
}