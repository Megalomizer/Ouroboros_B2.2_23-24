using OuroborosEvents.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosEvents.MVVM.ViewModels
{
    public class YourAccountVM
    {
        public User User { get; set; }
        public YourAccountVM()
        {
            User = App.LoggedInUser;
        }
    }
}
