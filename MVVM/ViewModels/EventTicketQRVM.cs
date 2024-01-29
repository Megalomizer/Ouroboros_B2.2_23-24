using Newtonsoft.Json;
using OuroborosEvents.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace OuroborosEvents.MVVM.ViewModels
{
    public class EventTicketQRVM
    {
        public User? User { get; set; }
        public string QrJson { get; set; }

        public EventTicketQRVM()
        {
            User = App.LoggedInUser;
            if (User != null)
                QrJson = System.Text.Json.JsonSerializer.Serialize<User>(User);
            

        }
    }
}
        //public void Main() 
        //{
           // EventTicketQRVM viewModel = new EventTicketQRVM();

            //User? user = JsonSerializer.Deserialize<User>(QrJson);
        //}

    //}
//}
