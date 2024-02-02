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
            // 
            var uneditedActivity = BindingContext as ActivityDetailsVM;

            DateTime dateTime = StartingDate.Date;
            dateTime.Add(StartingTime.Time);

            Activity activity = new Activity()
            {
                Id = uneditedActivity.Activity.Id,
                Name = Name.Text,
                Description = Description.Text,
                StartDateTime = dateTime,
                Duration = Duration.Time,
                EventId = uneditedActivity.Activity.EventId,
                ExhibitId = uneditedActivity.Activity.ExhibitId
            };

            if (activity.Name == null || activity.Name == "")
                activity.Name = uneditedActivity.Activity.Name;
            if (activity.Description == null || activity.Description == "")
                activity.Description = uneditedActivity.Activity.Description;
            if (activity.StartDateTime == null)
                activity.StartDateTime = uneditedActivity.Activity.StartDateTime;
            if (activity.Duration == null)
                activity.Duration = uneditedActivity.Activity.Duration;

            App.ActivityRepo.SaveEntity(activity);
            await Navigation.PopAsync();
        }
    }
}