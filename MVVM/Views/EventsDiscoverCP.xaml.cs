using OuroborosEvents.MVVM.ViewModels;

namespace OuroborosEvents.MVVM.Views;

public partial class EventsDiscoverCP : ContentPage
{
	public EventsDiscoverCP()
	{
		InitializeComponent();
		BindingContext = new AllEventsVM();
	}

	private async void EventSelected(object sender, EventArgs e)
	{
		var viewCell = sender as ViewCell;
		YourEventModelVM tappedCell = viewCell.BindingContext as YourEventModelVM;
		await Navigation.PushAsync(new EventsDetailsCP(tappedCell) { BindingContext = tappedCell });
	}

	private async void CreateEventButton(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CreateNewEventCP());
	}

	private void ResetList(object sender, EventArgs e)
	{
		BindingContext = null;
		BindingContext = new AllEventsVM();
		ListViewEvents.IsRefreshing = false;
	}
}