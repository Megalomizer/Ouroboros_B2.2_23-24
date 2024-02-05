using CommunityToolkit.Maui.Alerts;
using OuroborosEvents.MVVM.Models;
using OuroborosEvents.MVVM.ViewModels;
using System.Windows.Input;

namespace OuroborosEvents.MVVM.Views;

public partial class EventsDetailsCP : ContentPage
{
    public YourEventModelVM EventModel { get; set; }

    public EventsDetailsCP(YourEventModelVM eventModel)
    {
        InitializeComponent();
        EventModel = eventModel;
    }

    private async void IntrestedEvent(object sender, EventArgs e)
    {
        string msg;
        // Check if Already exists
        List<EventGuest> eventGuests = App.EventGuestRepo.GetEntities();
        foreach (EventGuest eg in eventGuests)
        {
            if (eg.EventId == EventModel.Event.Id && eg.GuestId == App.LoggedInUser.Id)
            {
                // Remove from Event
                EventModel.Event.EventGuests.Remove(eg);

                // Remove from Guest
                Guest _guest = App.GuestRepo.GetEntity(App.LoggedInUser.Id);
                _guest.EventEntries.Remove(eg);

                // Delete EventGuest
                App.EventGuestRepo.DeleteEntity(eg);

                msg = "You have removed this event from your interested events";
                NotifyMessage(sender, e, msg);

                return;
            }
        }

        // Save the EventGuest
        EventGuest eventGuest = new EventGuest()
        {
            EventId = EventModel.Event.Id,
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
        Event _event = EventModel.Event;
        _event.EventGuests.Add(eventGuest);
        App.EventRepo.SaveEntity(_event);

        msg = "You have added this event to your interested events";
        NotifyMessage(sender, e, msg);
    }

    private void ShareEvent(object sender, EventArgs e)
    {
        string msg = "This will be implemented on a later date";
        NotifyMessage(sender, e, msg);
    }

    private void GetEventTicket(object sender, EventArgs e)
    {
        // Check if already user owns a ticket
        EventGuest? eventGuest = null;
        string msg;

        List<EventGuest> eventGuests = App.EventGuestRepo.GetEntities();
        foreach (EventGuest eg in eventGuests)
        {
            if (eg.EventId == EventModel.Event.Id && eg.GuestId == App.LoggedInUser.Id)
            {
                if (eg.HasTicket == true)
                {
                    msg = "You already own a ticket to this event";
                    NotifyMessage(sender, e, msg);
                    return;
                }

                eventGuest = eg;
            }
        }

        if (eventGuest == null)
        {
            eventGuest = new EventGuest()
            {
                EventId = EventModel.Event.Id,
                GuestId = App.LoggedInUser.Id,
                HasTicket = true
            };                
        }
        else
        {
            eventGuest.HasTicket = true;
            if (eventGuest.EventId == null)
                eventGuest.EventId = EventModel.Event.Id;
            if (eventGuest.GuestId == null)
                eventGuest.GuestId = App.LoggedInUser.Id;
        }

        msg = "You now have a ticket to this event";
        NotifyMessage(sender, e, msg);

        App.EventGuestRepo.SaveEntity(eventGuest);
    }

    private async void DeleteEvent(object sender, EventArgs e)
    {
        string cancel = "Cancel";
        string destruction = "Delete";
        string reply = await DisplayActionSheet("Are you sure you want to delete this event?", cancel, destruction);
        if (reply == destruction)
        {
            var eventModel = BindingContext as YourEventModelVM;
            Event _event = App.EventRepo.GetEntity(eventModel.Event.Id);
            App.EventRepo.DeleteEntity(_event);
            await Navigation.PopAsync();
        }
    }

    private async void EditEvent(object sender, EventArgs e)
    {
        var eventData = BindingContext;
        YourEventModelVM vm = eventData as YourEventModelVM;
        EditEventModel em = new EditEventModel() { YourEventModelVM = vm, Addresses = App.AddressRepo.GetEntities() };
        await Navigation.PushAsync(new EditEventCP(vm) { BindingContext = em });
    }

    private async void ShowAllActivities(object sender, EventArgs e)
    {
        YourEventModelVM eventModel = (YourEventModelVM)BindingContext;
        Event _event = eventModel.Event;
        await Navigation.PushAsync(new ActivitiesOfEventCP(_event));
    }

    private async void ShowAllTickets(object sender, EventArgs e)
    {
        YourEventModelVM eventModel = (YourEventModelVM)BindingContext;
        Event ev = eventModel.Event;
        await Navigation.PushAsync(new EventAllTicketsCP() { BindingContext = new UsersEventTicketListVM(ev) });
    }

    private void NotifyMessage(object sender, EventArgs e, string message)
    {
        var PrimaryColor = Colors.White;
        var TextColor = Colors.Black;
        if (App.Current.Resources.TryGetValue("Primary", out var primaryColor))
            PrimaryColor = (Color)primaryColor;

        if (PrimaryColor != Colors.White)
            TextColor = Colors.White;

        var snackbar = Snackbar.Make(message, null, "", TimeSpan.FromSeconds(1.5),
            new CommunityToolkit.Maui.Core.SnackbarOptions 
            {
                BackgroundColor = PrimaryColor,
                CornerRadius = 15,
                TextColor = TextColor,
            });

        snackbar.Show();
    }
}