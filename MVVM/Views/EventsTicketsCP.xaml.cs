using OuroborosEvents.MVVM.Models;
using OuroborosEvents.MVVM.ViewModels;

namespace OuroborosEvents.MVVM.Views
{
	public partial class EventsTicketsCP : ContentPage
	{
		public EventsTicketsCP()
		{
			InitializeComponent();
			BindingContext = new EventTicketsVM();
		}

		private async void EventSelected(object sender, EventArgs e)
		{
			var viewCell = sender as ViewCell;
			YourEventModelVM tappedCell = viewCell.BindingContext as YourEventModelVM;
			await Navigation.PushAsync(new EventsDetailsCP(tappedCell) { BindingContext = tappedCell });
		}

		private void ResetList(object sender, EventArgs e)
		{
			BindingContext = null;
			BindingContext = new EventTicketsVM();
			ListViewEvents.IsRefreshing = false;
		}
	}
}