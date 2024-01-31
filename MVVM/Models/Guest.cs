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
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<EventGuest>? EventEntries { get; set; }
    }
}
