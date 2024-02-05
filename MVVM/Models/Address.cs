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
    [Table("Addresses")]
    public class Address : TableData
    {
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Event>? Events { get; set; } = null;

        [Unique, NotNull]
        public string? PostalCode { get; set; }
        public string? CountryCode { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
    }
}
