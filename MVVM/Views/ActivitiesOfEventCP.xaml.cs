using Xamarin.Google.Crypto.Tink.Subtle;
using OuroborosEvents.MVVM.ViewModels;
using OuroborosEvents.MVVM.Models;

namespace OuroborosEvents.MVVM.Views;

public partial class ActivitiesOfEventCP : ContentPage
{
	public ActivitiesOfEventCP()
	{
		InitializeComponent();
		BindingContext = new ActivitiesOfEventVM();
	}

    private void SelectedActivity(object sender, EventArgs e)
    {
		var viewCell = sender as ViewCell;
		var tappedItem = viewCell.BindingContext as ActivityDetailsVM;
		Navigation.PushAsync(new ActivityDetailsCP() { BindingContext = tappedItem });
    }
}