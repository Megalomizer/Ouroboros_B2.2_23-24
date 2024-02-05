using OuroborosEvents.Abstractions;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosEvents.MVVM.Models
{
    [Table("Exhibits")]
    public class Exhibit : TableData
    {
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Exhibitor? Exhibitor { get; set; }

        [ManyToMany((typeof(EventExhibit)), CascadeOperations = CascadeOperation.All)]
        public List<Event>? Events { get; set; } = null;

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Activity>? Activities { get; set; } = null;
    }
}
