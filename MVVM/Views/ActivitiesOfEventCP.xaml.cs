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

		Activity activity = viewCell.BindingContext as Activity;
		if (activity == null)
			return;

		ActivityDetailsVM vm = new ActivityDetailsVM()
		{
			Activity = activity,
			Event = new Event(),
			Exhibit = new Exhibit()
		};

        Event _event = new Event();
		if (activity.EventId != null)
		{
			_event = App.EventRepo.GetEntity((int)activity.EventId);
			vm.Event = _event;
		}

		Exhibit exhibit = new Exhibit();
		if (activity.ExhibitId != null)
		{
			exhibit = App.ExhibitRepo.GetEntity((int)activity.ExhibitId);
			vm.Exhibit = exhibit;
		}

		Navigation.PushAsync(new ActivityDetailsCP() { BindingContext = vm });
    }

    private async void AddNewActivity(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new ActivityCreationCP(Event));
    }

	private void ResetList(object sender, EventArgs e)
	{
		BindingContext = null;
		BindingContext = new ActivitiesOfEventVM(Event);
		ActivitiesList.IsRefreshing = false;
    }
}