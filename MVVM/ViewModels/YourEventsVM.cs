using OuroborosEvents.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosEvents.MVVM.ViewModels
{
    public class YourEventsVM
    {
        public List<YourEventModelVM> Events { get; set; }

        public YourEventsVM()
        {
            Events = GetYourEvents();
        }

        private List<YourEventModelVM> GetYourEvents()
        {
            List<YourEventModelVM>? yourEvents = new List<YourEventModelVM>();

            List<Event>? events = App.EventRepo.GetEntities();

            /*// Get a list of all events that the user attends
            if (App.LoggedInUser.GetType() == typeof(Guest))
            {
                foreach (Event e in events)
                {
                    foreach (Guest eg in e.EventGuests)
                    {
                        if (eg.Id == App.LoggedInUser.Id)
                        {
                            Address address = App.AddressRepo.GetEntity(e.AddressId);
                            if (address != null)
                                yourEvents.Add(new YourEventModelVM { Address = address, Event = e });
                        }
                    }
                }
            } // Get a list of all events the organiser owns
            else if (App.LoggedInUser.GetType() == typeof(Organiser))
            {
                foreach (Event e in events)
                {
                    Organiser organiser = App.OrganiserRepo.GetEntity(App.LoggedInUser.Id);
                    if (organiser != null)
                    {
                        Address address = App.AddressRepo.GetEntity(e.AddressId);
                        if (address != null)
                            yourEvents.Add(new YourEventModelVM { Address = address, Event = e });
                    }
                }
            } // Get a list of all events the exhibitor attends
            else if (App.LoggedInUser.GetType() == typeof(Exhibitor))
            {
                foreach (Event e in events)
                {
                    foreach (Exhibit exhibit in e.Exhibits)
                    {
                        if (exhibit.Exhibitor.Id == App.LoggedInUser.Id)
                        {
                            Address address = App.AddressRepo.GetEntity(e.AddressId);
                            if (address != null)
                                yourEvents.Add(new YourEventModelVM { Address = address, Event = e });
                        }
                    }
                }
            }*/

            // Temp
            foreach (Event e in events)
            {
                Address address = App.AddressRepo.GetEntity(e.AddressId);
                yourEvents.Add(new YourEventModelVM { Address = address, Event = e });
            }
            //

            return yourEvents;
        }
    }
}
