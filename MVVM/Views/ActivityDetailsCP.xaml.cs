using OuroborosEvents.MVVM.Models;
using OuroborosEvents.MVVM.ViewModels;

namespace OuroborosEvents.MVVM.Views;

public partial class ActivityDetailsCP : ContentPage
{
	public ActivityDetailsCP()
	{
		InitializeComponent();
	}

    private async void DeleteActivity(object sender, EventArgs e)
    {
        string cancel = "Cancel";
        string destruction = "Delete";
        string reply = await DisplayActionSheet("Are you sure you want to delete this activity?", cancel, destruction);
        
        if (reply == destruction)
        {
            var activityModel = BindingContext as ActivityDetailsVM;
            Activity activity = App.ActivityRepo.GetEntity(activityModel.Activity.Id);
            App.ActivityRepo.DeleteEntity(activity);
            await Navigation.PopAsync();
        }
    }

    private async void EditActivity(object sender, EventArgs e)
    {
        ActivityDetailsVM vm = BindingContext as ActivityDetailsVM;
        await Navigation.PushAsync(new ActivityEditCP() { BindingContext = vm });
    }
}