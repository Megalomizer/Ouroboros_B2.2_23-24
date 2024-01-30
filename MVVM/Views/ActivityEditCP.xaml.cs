using OuroborosEvents.MVVM.Models;
using OuroborosEvents.MVVM.ViewModels;

namespace OuroborosEvents.MVVM.Views
{
    public partial class ActivityEditCP : ContentPage
    {
        public ActivityEditCP()
        {
            InitializeComponent();
        }

        private async void UpdateActivity(object sender, EventArgs e)
        {
            var uneditedActivity = sender as ActivityDetailsVM;

            DateTime dateTime = StartingDate.Date;
            dateTime.Add(StartingTime.Time);

            Activity activity = new Activity()
            {
                Name = Name.Text,
                Description = Description.Text,
                StartDateTime = dateTime,
                Duration = Duration.Time,
            };

            if (activity.Name == null || activity.Name == "")
                activity.Name = uneditedActivity.Event.Name;
            if (activity.Description == null || activity.Description == "")
                activity.Description = uneditedActivity.Event.Description;
            if (activity.StartDateTime == null)
                activity.StartDateTime = uneditedActivity.Event.StartingDate;
            if (activity.Duration == null)
                activity.Duration = uneditedActivity.Event.DailyOpeningTime;

            App.ActivityRepo.SaveEntity(activity);
            await Navigation.PopAsync();
        }
    }
}