using OuroborosEvents.MVVM.Models;

namespace OuroborosEvents.MVVM.Views;

public partial class CreateNewEventCP : ContentPage
{
	public CreateNewEventCP()
	{
		InitializeComponent();
	}

    private async void SaveEvent_btn(object sender, EventArgs e)
    {
		Guest guest = App.GuestRepo.GetEntity(3);

		Event _event = new Event
		{
			Name = Name.Text,
			Description = Description.Text,
			StartingDate = StartingDate.Date,
			EndingDate = EndingDate.Date,
			DailyOpeningTime = StartingTime.Time,
			DailyClosingTime = EndingTime.Time,
			EventGuests = [guest],
			OrganiserId = 0,
			AddressId = 0,
		};
		App.EventRepo.SaveEntity(_event);

		await Navigation.PopAsync();
		await Navigation.PopAsync();
		await Navigation.PushAsync(new EventsYourEventsCP());
    }
}