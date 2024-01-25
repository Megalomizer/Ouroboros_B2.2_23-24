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
    [Table("Events")]
    public class Event : TableData
    {
        public string? Name { get; set; }
        public string? Description { get; set; } = null;

        // Openings dag
        public DateTime? StartingDate { get; set; }
        // Laatste dag
        public DateTime? EndingDate { get; set; }
        // Dagelijkse openings tijd
        public TimeSpan? DailyOpeningTime { get; set; } = null;
        // Dagelijkse sluitings tijd
        public TimeSpan? DailyClosingTime { get; set; } = null;

        [ForeignKey(typeof(Organiser))]
        public int OrganiserId { get; set; }

        [ManyToMany((typeof(EventGuest)), CascadeOperations = CascadeOperation.All)]
        public List<Guest>? EventGuests { get; set; } = null;

        [ForeignKey(typeof(Address))]
        public int AddressId { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Activity>? Activities { get; set; } = null;

        [ManyToMany((typeof(EventExhibit)), CascadeOperations = CascadeOperation.All)]
        public List<Exhibit>? Exhibits { get; set; } = null;
    }
}
