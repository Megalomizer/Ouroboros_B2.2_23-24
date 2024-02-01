using OuroborosEvents.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosEvents.MVVM.ViewModels
{
    public class EventUserTicketVM
    {
        public Guest Guest { get; set; } = App.GuestRepo.GetEntity(App.LoggedInUser.Id);
        public YourEventModelVM EventModel { get; set; }
    }
}
