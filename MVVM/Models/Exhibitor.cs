using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosEvents.MVVM.Models
{
    [Table("Exhibitors")]
    public class Exhibitor : User
    {
        [ForeignKey(typeof(Exhibitor))]
        public int ExhibitId { get; set; }
    }
}
