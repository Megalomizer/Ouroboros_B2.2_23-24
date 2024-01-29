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
    [Table("Tickets")]
    public class Ticket : TableData
    {
        [ForeignKey(typeof(Guest))]
        public int GuestId { get; set; }
        [ForeignKey(typeof(Event))]
        public int EventId { get; set; }

        public bool IsScanned { get; set; } = false;
    }
}
