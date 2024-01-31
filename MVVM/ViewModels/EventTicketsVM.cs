using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OuroborosEvents.MVVM.Models;

namespace OuroborosEvents.MVVM.ViewModels
{
    public class EventTicketsVM
    {
        public List<YourEventModelVM> Events { get; set; }

        public EventTicketsVM()
        {
            Events = GetYourEvents();
        }

        private List<YourEventModelVM> GetYourEvents()
        {
            List<YourEventModelVM>? yourEvents = new List<YourEventModelVM>();

            List<Event>? events = App.EventRepo.GetEntities();           

            // Get a list of all events that the user attends
            if (App.LoggedInUser.GetType() == typeof(Guest))
            {
                Guest guest = App.GuestRepo.GetEntity(App.LoggedInUser.Id);

                List<EventGuest> eventGuests = App.EventGuestRepo.GetEntities();
                foreach (EventGuest eg in eventGuests)
                {
                    if (eg.GuestId == guest.Id && eg.HasTicket == true)
                    {
                        Event ev = App.EventRepo.GetEntity(eg.EventId);
                        YourEventModelVM vm = new YourEventModelVM()
                        {
                            Event = ev,
                            Address = App.AddressRepo.GetEntity(ev.AddressId)
                        };
                        yourEvents.Add(vm);
                    }
                }

            } 

            return yourEvents;
        }
    }
}
