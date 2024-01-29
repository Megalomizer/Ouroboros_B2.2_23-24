using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosEvents.MVVM.Models
{
    [Table("Guests")]
    public class Guest : User
    {
        [ManyToMany((typeof(EventGuest)), CascadeOperations = CascadeOperation.All)]
        public List<Event>? EventEntries { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Ticket>? Tickets { get; set; }
    }
}
