using OuroborosEvents.MVVM.Models;
using OuroborosEvents.MVVM.ViewModels;
using System.Windows.Input;

namespace OuroborosEvents.MVVM.Views;

public partial class EventsDetailsCP : ContentPage
{
    public EventsDetailsCP()
	{
		InitializeComponent();
	}

    private void IntrestedEvent(object sender, EventArgs e)
    {

    }

    private void ShareEvent(object sender, EventArgs e)
    {

    }

    private void GetEventTicket(object sender, EventArgs e)
    {

    }

    private async void DeleteEvent(object sender, EventArgs e)
    {
        string cancel = "Cancel";
        string destruction = "Delete";
        string reply = await DisplayActionSheet("Are you sure you want to delete this event?", cancel, destruction);
        if(reply == destruction)
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
        await Navigation.PushAsync(new EditEventCP() { BindingContext = eventData });
    }

    private async void ShowAllActivities(object sender, EventArgs e)
    {
        YourEventModelVM eventModel = (YourEventModelVM)BindingContext;
        Event _event = eventModel.Event;
        await Navigation.PushAsync(new ActivitiesOfEventCP(_event));
    }
}