using OuroborosEvents.MVVM.Models;

namespace OuroborosEvents.MVVM.Views;

public partial class ActivityCreationCP : ContentPage
{
	public Event ActivityEvent { get; set; }
	public ActivityCreationCP(Event _event)
	{
		InitializeComponent();
		ActivityEvent = _event;
	}

    private async void SaveActivity(object sender, EventArgs e)
    {
		Activity activity = new Activity
		{
			Name = Name_Entry.Text,
			Description = Activity_Description.Text,
			StartDateTime = Activity_StartTime.Date,
			Duration = Activity_Duration.Time,
			EventId = ActivityEvent.Id
        };

		App.ActivityRepo.SaveEntity(activity);

		await Navigation.PopAsync();
    }
}