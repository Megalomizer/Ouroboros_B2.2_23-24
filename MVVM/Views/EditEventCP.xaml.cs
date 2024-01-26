using OuroborosEvents.MVVM.Models;
using OuroborosEvents.MVVM.ViewModels;

namespace OuroborosEvents.MVVM.Views;

public partial class EditEventCP : ContentPage
{
	public EditEventCP()
	{
		InitializeComponent();
	}

    private async void UpdateEvent_Clicked(object sender, EventArgs e)
    {
		var uneditedEvent = sender as YourEventModelVM;
		Event _event = new Event()
		{
			Name = Name.Text,
			Description = Description.Text,
			StartingDate = StartingDate.Date,
			EndingDate = EndingDate.Date,
			DailyOpeningTime = StartingTime.Time,
			DailyClosingTime = EndingTime.Time,
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

		App.EventRepo.SaveEntity(_event);
		await Navigation.PopAsync();
	}
}