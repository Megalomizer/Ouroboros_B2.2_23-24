using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosEvents.MVVM.Models
{
    [Table("Organisers")]
    public class Organiser : User
    {
        public string? OrganisationName {  get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Event>? Events { get; set; }
    }
}
