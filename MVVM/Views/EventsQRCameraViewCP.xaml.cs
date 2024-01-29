using Camera.MAUI;

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
            });
        }
    }

    private void QRCodeView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
           
        });
    }
}