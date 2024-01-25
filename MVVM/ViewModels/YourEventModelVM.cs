using OuroborosEvents.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosEvents.MVVM.ViewModels
{
    public class YourEventModelVM
    {
        public Event? Event { get; set; }
        public Address? Address { get; set; }
    }
}
