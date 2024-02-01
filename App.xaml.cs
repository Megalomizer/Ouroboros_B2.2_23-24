using OuroborosEvents.Repositories;
using OuroborosEvents.MVVM.Models;
using OuroborosEvents.MVVM.Views;
using System.ComponentModel;

namespace OuroborosEvents
{
    public partial class App : Application
    {
        public static User? LoggedInUser { get; set; }

        public static BaseRepository<Activity>? ActivityRepo { get; private set; }
        public static BaseRepository<Address>? AddressRepo { get; private set; }
        public static BaseRepository<Event>? EventRepo { get; private set; }
        public static BaseRepository<EventGuest>? EventGuestRepo { get; private set; }
        public static BaseRepository<Exhibit>? ExhibitRepo { get; private set; }
        public static BaseRepository<Exhibitor>? ExhibitorRepo { get; private set; }
        public static BaseRepository<Guest>? GuestRepo { get; private set; }
        public static BaseRepository<Organiser>? OrganiserRepo { get; private set; }


        public App(BaseRepository<Activity> activityRepo, BaseRepository<Address> addressRepo,
            BaseRepository<Event> eventRepo, BaseRepository<EventGuest> eventGuestRepo,
            BaseRepository<Exhibit> exhibitRepo, BaseRepository<Exhibitor> exhibitorRepo,
            BaseRepository<Guest> guestRepo, BaseRepository<Organiser> organiserRepo)
        {
            InitializeComponent();

            ActivityRepo = activityRepo;
            AddressRepo = addressRepo;
            EventRepo = eventRepo;
            EventGuestRepo = eventGuestRepo;
            ExhibitRepo = exhibitRepo;
            ExhibitorRepo = exhibitorRepo;
            GuestRepo = guestRepo;
            OrganiserRepo = organiserRepo;

            MainPage = new NavigationPage(new MainPage());

            // Create Zuyd Address 
            Address ZuydAddress = new Address
            {
                City = "Heerlen",
                CountryCode = "NL",
                HouseNumber = "300",
                PostalCode = "6419DJ",
                Street = "Nieuw Eyckholt"
            };
            addressRepo.SaveEntity(ZuydAddress);
        }
    }
}
