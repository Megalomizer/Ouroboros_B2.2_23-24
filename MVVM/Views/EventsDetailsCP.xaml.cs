using OuroborosEvents.MVVM.ViewModels;

namespace OuroborosEvents.MVVM.Views;

public partial class EventsDetailsCP : ContentPage
{
	public EventsDetailsCP()
	{
		InitializeComponent();
	}

    private void IntrestedEvent(object sender, EventArgs e)
    {

    }

    private void ShareEvent(object sender, EventArgs e)
    {

    }

    private void GetEventTicket(object sender, EventArgs e)
    {

    }

    private async void ShowAllActivities(object sender, EventArgs e)
    {
        var eventData = sender as YourEventModelVM;
        await Navigation.PushAsync(new ActivitiesOfEventCP() { BindingContext = eventData });
    }
}