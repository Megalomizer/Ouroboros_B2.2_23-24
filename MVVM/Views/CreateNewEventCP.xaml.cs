using OuroborosEvents.MVVM.Models;
using OuroborosEvents.MVVM.ViewModels;

namespace OuroborosEvents.MVVM.Views;

public partial class CreateNewEventCP : ContentPage
{
	public CreateNewEventCP()
	{
		InitializeComponent();
	}

    private async void SaveEvent_btn(object sender, EventArgs e)
    {
		Guest guest = null;
		Organiser organiser = null;

        if (App.LoggedInUser.GetType() == typeof(Guest))
			guest = App.GuestRepo.GetEntity(App.LoggedInUser.Id);
        else if (App.LoggedInUser.GetType() == typeof(Organiser))
			organiser = App.OrganiserRepo.GetEntity(App.LoggedInUser.Id);

        Event _event = new Event
		{
			Name = Name.Text,
			Description = Description.Text,
			StartingDate = StartingDate.Date,
			EndingDate = EndingDate.Date,
			DailyOpeningTime = StartingTime.Time,
			DailyClosingTime = EndingTime.Time,
			EventGuests = [],
			OrganiserId = 0,
			AddressId = 0,
		};
		
		if(App.LoggedInUser.GetType() == typeof(Guest))
            _event.EventGuests.Add(guest);
		else if(App.LoggedInUser.GetType() == typeof(Organiser))
			_event.OrganiserId = App.LoggedInUser.Id;

		App.EventRepo.SaveEntity(_event);

		if(App.LoggedInUser.GetType() == typeof(Guest))
		{
			guest.EventEntries.Add(_event);
			App.GuestRepo.SaveEntity(guest);
		}
		else if(App.LoggedInUser.GetType() == typeof(Organiser))
		{
			organiser.Events.Add(_event);
			App.OrganiserRepo.SaveEntity(organiser);
		}

		await Navigation.PopAsync();
    }
}