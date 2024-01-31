using OuroborosEvents.MVVM.ViewModels;

namespace OuroborosEvents.MVVM.Views;

public partial class EventsTicketsCP : ContentPage
{
	public EventsTicketsCP()
	{
		InitializeComponent();
		BindingContext = new EventTicketQRVM();
	}

    private void CameraView_CamerasLoaded(object sender, EventArgs e)
    {

    }

    private async void QRTESTBUTTON_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EventsQRCodeCP());
    }
}