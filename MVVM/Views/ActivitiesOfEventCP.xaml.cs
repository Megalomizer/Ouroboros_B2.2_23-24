using OuroborosEvents.MVVM.ViewModels;
using OuroborosEvents.MVVM.Models;

namespace OuroborosEvents.MVVM.Views;

public partial class ActivitiesOfEventCP : ContentPage
{
	public Event Event { get; set; }
	public ActivitiesOfEventCP(Event _event)
	{
		InitializeComponent();
		Event = _event;
		BindingContext = new ActivitiesOfEventVM(_event);
	}

    private void SelectedActivity(object sender, EventArgs e)
    {
		var viewCell = sender as ViewCell;
		var tappedItem = viewCell.BindingContext as ActivityDetailsVM;
		Navigation.PushAsync(new ActivityDetailsCP() { BindingContext = tappedItem });
    }

    private async void AddNewActivity(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new ActivityCreationCP(Event));
    }

	private async void ResetList(object sender, EventArgs e)
	{
		BindingContext = null;
		BindingContext = new ActivitiesOfEventVM(Event);
		ActivitiesList.IsRefreshing = false;

    }
}