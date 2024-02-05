using OuroborosEvents.MVVM.Models;

namespace OuroborosEvents.MVVM.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            OnCreate();
        }

        private async void OnCreate()
        {
            App.LoggedInUser = null;
            if(await SecureStorage.GetAsync("Username") is string Username && await SecureStorage.GetAsync("Password") is string Password && await SecureStorage.GetAsync("Type") is string Type)
            {
                // Find user and log him in!
                if(Type == "Guest")
                {
                    foreach (Guest user in App.GuestRepo.GetEntities())
                    {
                        if (user.Email == Username && user.Password == Password)
                        {
                            App.LoggedInUser = user;
                            await Navigation.PushAsync(new EventsHomeTP());
                            return;
                        }
                    }
                }
                else if (Type == "Organiser")
                {
                    foreach (Organiser user in App.OrganiserRepo.GetEntities())
                    {
                        if (user.Email == Username && user.Password == Password)
                        {
                            App.LoggedInUser = user;
                            await Navigation.PushAsync(new EventsHomeTP());
                            return;
                        }
                    }
                }
                else if (Type == "Exhibitor")
                {
                    foreach (Exhibitor user in App.ExhibitorRepo.GetEntities())
                    {
                        if (user.Email == Username && user.Password == Password)
                        {
                            App.LoggedInUser = user;
                            await Navigation.PushAsync(new EventsHomeTP());
                            return;
                        }
                    }
                }

                // Couldnt log in
                if(App.LoggedInUser == null)
                {
                    SecureStorage.Remove("Username");
                    SecureStorage.Remove("Password");
                    SecureStorage.Remove("Type");
                }
            }
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
                User guest = new Guest() { Password = PasswordEnt.Text, Email = UsernameEnt.Text, };

                foreach(Guest g in App.GuestRepo.GetEntities())
                {
                    if(g.Email == guest.Email && g.Password == guest.Password)
                    {
                        App.LoggedInUser = g;
                        await SecureStorage.SetAsync("Username", g.Email);
                        await SecureStorage.SetAsync("Password", g.Password);
                        await SecureStorage.SetAsync("Type", "Guest");
                        await Navigation.PushAsync(new EventsHomeTP());
                        return;
                    }
                }
                foreach(Exhibitor ex in App.ExhibitorRepo.GetEntities())
                {
                    if (ex.Email == guest.Email && ex.Password == guest.Password)
                    {
                        App.LoggedInUser = ex;
                        await SecureStorage.SetAsync("Username", ex.Email);
                        await SecureStorage.SetAsync("Password", ex.Password);
                        await SecureStorage.SetAsync("Type", "Exhibitor");
                        await Navigation.PushAsync(new EventsHomeTP());
                        return;
                    }
                }
                foreach (Organiser o in App.OrganiserRepo.GetEntities())
                {
                    if (o.Email == guest.Email && o.Password == guest.Password)
                    {
                        App.LoggedInUser = o;
                        await SecureStorage.SetAsync("Username", o.Email);
                        await SecureStorage.SetAsync("Password", o.Password);
                        await SecureStorage.SetAsync("Type", "Organiser");
                        await Navigation.PushAsync(new EventsHomeTP());
                        return;
                    }
                }

                await DisplayAlert("Incorrect Info", "Not all info has been correctly added. Try again", "ok");
                PasswordEnt.Text = "";
            }
        }

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
