using OuroborosEvents.MVVM.ViewModels;

namespace OuroborosEvents.MVVM.Views
{
	public partial class EventsYourEventsCP : ContentPage
	{

		public YourEventsVM viewModel { get; set; }

        public EventsYourEventsCP()
		{
			InitializeComponent();
			BindingContext = new YourEventsVM();
		}

        private async void EventSelected(object sender, EventArgs e)
        {
			var viewCell = sender as ViewCell;
			var tappedCell = viewCell.BindingContext as YourEventModelVM;
			await Navigation.PushAsync(new EventsDetailsCP() { BindingContext = tappedCell });
        }

        private async void CreateEventButton(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new CreateNewEventCP());
        }

        public async void ResetList(object sender, EventArgs e)
        {
            viewModel = new YourEventsVM();
            BindingContext = null;
            BindingContext = viewModel;
            ListViewEvents.IsRefreshing = false;
        }
    }
}