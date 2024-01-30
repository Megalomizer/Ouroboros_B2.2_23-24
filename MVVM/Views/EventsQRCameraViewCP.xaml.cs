using Camera.MAUI;
using Plugin.LocalNotification;
using System.Text.Json;
using System.IO;
using Plugin.LocalNotification.AndroidOption;
using OuroborosEvents.MVVM.Models;

namespace OuroborosEvents.MVVM.Views;

public partial class EventsQRCameraViewCP : ContentPage
{
	public EventsQRCameraViewCP()
	{
		InitializeComponent();
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

            var Test = new NotificationRequest
            {
                NotificationId = 50,
                Title = $"{contactShared.FirstName} {contactShared.LastName}",
                Subtitle = "You have succesfully scanned this QR code!",
                Description = $"{contactInfo}",
                BadgeNumber = 1,
            };
            LocalNotificationCenter.Current.Show(Test);

            await Navigation.PopAsync();
        });
    }
}