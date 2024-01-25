using OuroborosEvents.MVVM.Models;

namespace OuroborosEvents.MVVM.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        
        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            App.LoggedInUser = null;
            bool UsernameEmpty = string.IsNullOrEmpty(UsernameEnt.Text);
            bool PasswordEmpty = string.IsNullOrEmpty(PasswordEnt.Text);

            if (UsernameEmpty || PasswordEmpty)
            {
                PasswordEnt.Text = "";
                await DisplayAlert("Incorrect Info", "Not all info has been correctly added. Try again", "ok");
            }
            else
            {
                Guest guest = new Guest() { Password = PasswordEnt.Text, Email = UsernameEnt.Text, };
                List<Guest> AllGuests = App.GuestRepo.GetEntities();

                foreach(Guest g in AllGuests)
                {
                    if(g.Email == guest.Email && g.Password == guest.Password)
                    {
                        App.LoggedInUser = g;
                    }
                }

                if (App.LoggedInUser != null)
                {
                    Navigation.PushAsync(new EventsHomeTP());
                }
                else
                {
                    await DisplayAlert("Incorrect Info", "Not all info has been correctly added. Try again", "ok");
                    PasswordEnt.Text = "";
                }
            }
        }

        private void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
