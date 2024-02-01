using OuroborosEvents.MVVM.Models;
using OuroborosEvents.MVVM.ViewModels;

namespace OuroborosEvents.MVVM.Views;

public partial class EditEventCP : ContentPage
{
	public YourEventModelVM YourEventModelVM { get; set; }

	public EditEventCP(YourEventModelVM yourEventModelVM)
	{
		InitializeComponent();
		YourEventModelVM = yourEventModelVM;
	}

    private async void UpdateEvent_Clicked(object sender, EventArgs e)
    {
		var uneditedEvent = YourEventModelVM;
		Event _event = new Event()
		{
			Id = uneditedEvent.Event.Id,

			Name = Name.Text,
			Description = Description.Text,
			StartingDate = StartingDate.Date,
			EndingDate = EndingDate.Date,
			DailyOpeningTime = StartingTime.Time,
			DailyClosingTime = EndingTime.Time,

			EventGuests = uneditedEvent.Event.EventGuests,
			Activities = uneditedEvent.Event.Activities,
			AddressId = uneditedEvent.Event.AddressId,
			Exhibits = uneditedEvent.Event.Exhibits,
			OrganiserId = uneditedEvent.Event.OrganiserId
		};

		if (_event.Name == null || _event.Name == "")
			_event.Name = uneditedEvent.Event.Name;
		if (_event.Description == null || _event.Description == "")
			_event.Description = uneditedEvent.Event.Description;
		if (_event.StartingDate == null)
			_event.StartingDate = uneditedEvent.Event.StartingDate;
        if (_event.EndingDate == null)
            _event.EndingDate = uneditedEvent.Event.EndingDate;
        if (_event.DailyOpeningTime == null)
            _event.DailyOpeningTime = uneditedEvent.Event.DailyOpeningTime;
        if (_event.DailyClosingTime == null)
            _event.DailyClosingTime = uneditedEvent.Event.DailyClosingTime;

		var differenceInTimeInSeconds = _event.StartingDate.Value.TimeOfDay.Seconds - _event.DailyOpeningTime.Value.Seconds;
		_event.StartingDate.Value.AddSeconds(differenceInTimeInSeconds);

		differenceInTimeInSeconds = _event.EndingDate.Value.TimeOfDay.Seconds - _event.DailyClosingTime.Value.Seconds;
		_event.EndingDate.Value.AddSeconds(differenceInTimeInSeconds);

		App.EventRepo.SaveEntity(_event);
		await Navigation.PopAsync();
	}
}