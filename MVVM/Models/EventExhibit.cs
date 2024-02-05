using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosEvents.MVVM.Models
{
    [Table("EventExhibits")]
    public class EventExhibit
    {
        [ForeignKey(typeof(Event))]
        public int EventId { get; set; }

        [ForeignKey(typeof(Exhibit))]
        public int ExhibitId { get; set; }
    }
}
