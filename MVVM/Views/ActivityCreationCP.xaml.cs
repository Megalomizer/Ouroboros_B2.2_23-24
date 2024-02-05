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
		DateTime dateTime = Activity_StartDate.Date.Value.Date;
        dateTime = dateTime.AddHours(Activity_StartTime.Time.Value.Hours);
        dateTime = dateTime.AddMinutes(Activity_StartTime.Time.Value.Minutes);
        dateTime = dateTime.AddSeconds(Activity_StartTime.Time.Value.Seconds);

        Activity activity = new Activity
		{
			Name = Name_Entry.Text,
			Description = Activity_Description.Text,
			StartDateTime = dateTime,
			Duration = Activity_Duration.Time,
			EventId = ActivityEvent.Id
        };

		App.ActivityRepo.SaveEntity(activity);

		await Navigation.PopAsync();
    }
}