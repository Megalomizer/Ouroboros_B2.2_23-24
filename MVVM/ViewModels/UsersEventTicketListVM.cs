using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OuroborosEvents.MVVM.Models;

namespace OuroborosEvents.MVVM.ViewModels
{
    public class UsersEventTicketListVM
    {
        public List<Guest>? Guests { get; set; }
        public Event? Event { get; set; }

        public UsersEventTicketListVM(Event ev)
        {
            Event = ev;
            Guests = getGuestsWithTicket(Event);
        }

        private List<Guest> getGuestsWithTicket(Event ev)
        {
            List<Guest> guests = new List<Guest>();
            foreach (EventGuest eg in App.EventGuestRepo.GetEntities())
            {
                if(eg.EventId == ev.Id && eg.HasTicket == true)
                    guests.Add(App.GuestRepo.GetEntity(eg.GuestId));
            }
            return guests;
        } 
    }
}
