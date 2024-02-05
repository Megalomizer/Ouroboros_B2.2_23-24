using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OuroborosEvents.MVVM.Models;

namespace OuroborosEvents.MVVM.ViewModels
{
    public class AllEventsVM
    {
        public List<YourEventModelVM> Events { get; set; }

        public AllEventsVM()
        {
            Events = GetAllEvents();
        }

        private List<YourEventModelVM> GetAllEvents()
        {
            List<YourEventModelVM> events = new List<YourEventModelVM>();
            List<Event> allEvents = App.EventRepo.GetEntities();

            foreach (Event e in allEvents)
            {
                YourEventModelVM vm = new YourEventModelVM()
                {
                    Event = e,
                    Address = App.AddressRepo.GetEntity(e.AddressId)
                };
                events.Add(vm);
            }

            return events;
        }
    }
}
