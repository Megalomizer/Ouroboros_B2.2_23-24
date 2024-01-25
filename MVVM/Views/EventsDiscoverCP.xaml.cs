namespace OuroborosEvents.MVVM.Views;

public partial class EventsDiscoverCP : ContentPage
{
	public EventsDiscoverCP()
	{
		InitializeComponent();
		BindingContext = App.LoggedInUser;
	}
}