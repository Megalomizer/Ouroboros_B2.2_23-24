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
    [Table("EventGuests")]
    public class EventGuest : TableData
    {
        [ForeignKey(typeof(Event))]
        public int EventId { get; set; }

        [ForeignKey(typeof(Guest))]
        public int GuestId { get; set; }

        public bool HasTicket { get; set; } = false;
        public bool TicketIsScanned { get; set; } = false;
    }
}
