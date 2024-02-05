using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OuroborosEvents.MVVM.Models;

namespace OuroborosEvents.MVVM.ViewModels
{
    public class EditEventModel
    {
        public YourEventModelVM YourEventModelVM { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
