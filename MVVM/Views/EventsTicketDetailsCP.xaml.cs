using OuroborosEvents.MVVM.ViewModels;
using OuroborosEvents.MVVM.Models;
using System.Windows.Input;

namespace OuroborosEvents.MVVM.Views;

public partial class EventsTicketDetailsCP : ContentPage
{
    public YourEventModelVM eventModel { get; set; }
    public EventsTicketDetailsCP(YourEventModelVM _eventModel) 
	{
		InitializeComponent();
        BindingContext = new EventTicketsVM();
        eventModel = _eventModel;
    }
    private async void IntrestedEvent(object sender, EventArgs e)
    {
        // Check if Already exists
        List<EventGuest> eventGuests = App.EventGuestRepo.GetEntities();
        foreach (EventGuest eg in eventGuests)
        {
            if (eg.EventId == eventModel.Event.Id && eg.GuestId == App.LoggedInUser.Id)
            {
                // Remove from Event
                eventModel.Event.EventGuests.Remove(eg);

                // Remove from Guest
                Guest _guest = App.GuestRepo.GetEntity(App.LoggedInUser.Id);
                _guest.EventEntries.Remove(eg);

                // Delete EventGuest
                App.EventGuestRepo.DeleteEntity(eg);

                return;
            }
        }
        // Save the EventGuest
        EventGuest eventGuest = new EventGuest()
        {
            EventId = eventModel.Event.Id,
            GuestId = App.LoggedInUser.Id,
        };
        App.EventGuestRepo.SaveEntity(eventGuest);

        // Get the new ID
        List<EventGuest> AllEventGuests = App.EventGuestRepo.GetEntities();
        foreach (EventGuest eg in AllEventGuests)
        {
            if (eg.EventId == eventGuest.EventId && eg.GuestId == eventGuest.GuestId)
            {
                eventGuest = eg;
                break;
            }
        }

        // Save the updated Guest
        Guest guest = App.GuestRepo.GetEntity(App.LoggedInUser.Id);
        guest.EventEntries.Add(eventGuest);
        App.GuestRepo.SaveEntity(guest);

        // Save the updated Event
        Event _event = eventModel.Event;
        _event.EventGuests.Add(eventGuest);
        App.EventRepo.SaveEntity(_event);
    }
    private async void ShowAllActivities(object sender, EventArgs e)
    {
        YourEventModelVM eventModel = (YourEventModelVM)BindingContext;
        Event _event = eventModel.Event;
        await Navigation.PushAsync(new ActivitiesOfEventCP(_event));
    }

    private async void ButtonGetTicket_Clicked(object sender, EventArgs e)
    {
        EventUserTicketVM vm = new EventUserTicketVM() { EventModel = eventModel };
        await Navigation.PushAsync(new EventsQRCodeCP() { BindingContext = vm });
    }
}
