using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OuroborosEvents.MVVM.Models;

namespace OuroborosEvents.MVVM.ViewModels
{
    public class ActivityDetailsVM
    {
        public Activity? Activity { get; set; }
        public Event? Event { get; set; }
    }
}
