using OuroborosEvents.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosEvents.MVVM.Models
{
    public class User : TableData
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Unique, EmailAddress, Required]
        public string? Email { get; set; }
        [Unique, Phone]
        public int PhoneNumber { get; set; }
        public string? LinkedIn { get; set; } = null;
        public string? Password { get; set; }
    }
}
