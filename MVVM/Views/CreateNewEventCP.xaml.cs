using OuroborosEvents.MVVM.Models;
using OuroborosEvents.MVVM.ViewModels;

namespace OuroborosEvents.MVVM.Views;

public partial class CreateNewEventCP : ContentPage
{
	public CreateNewEventCP()
	{
		InitializeComponent();
	}

	private void RefreshPreviousPage(object sender, EventArgs e)
	{
		var stack = Application.Current.MainPage.Navigation.NavigationStack;
		var previousPageId = stack.Count - 2;
		var previousPage = stack[previousPageId];
		
        if (previousPage is EventsYourEventsCP cp)
            cp.ResetList(sender, e);
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

		RefreshPreviousPage(sender, e);
		await Navigation.PopAsync();
    }
}