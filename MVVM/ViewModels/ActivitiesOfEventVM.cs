using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OuroborosEvents.MVVM.Models;

namespace OuroborosEvents.MVVM.ViewModels
{
    public class ActivitiesOfEventVM
    {
        public List<Activity>? Activities {  get; set; }
        public Event? Event { get; set; }

        public ActivitiesOfEventVM(Event _event)
        {
            Event = _event;
            Activities = GetActivitiesByEvent(_event);
        }

        public List<Activity>? GetActivitiesByEvent(Event _event)
        {
            List<Activity>? a = App.ActivityRepo.GetEntities();
            List<Activity>? activities = new List<Activity>();

            foreach(Activity activity in a)
            {
                if(activity.EventId == _event.Id)
                {
                    activities.Add(activity);
                }
            }

            return activities;
        }
    }
}
