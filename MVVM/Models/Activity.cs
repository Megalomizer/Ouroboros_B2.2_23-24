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
    [Table("Activities")]
    public class Activity : TableData
    {
        [ForeignKey(typeof(Event))]
        public int? EventId { get; set; } = null;

        [ForeignKey(typeof(Exhibit))]
        public int? ExhibitId { get; set; } = null;

        public string? Name { get; set; }
        public string? Description { get; set; }
        public TimeSpan? Duration { get; set; }
        public DateTime? StartDateTime { get; set; }
    }
}
