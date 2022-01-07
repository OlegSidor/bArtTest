using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace bArtTest.Models
{
    [Index(nameof(Account.name), IsUnique = true)]

    public class Account
    {

        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public string Incidentname { get; set; }
        public Incident incident { get; set; }
        
        [JsonIgnore]
        [IgnoreDataMember]
        public List<Contact> contacts { get; set; }

    }
}
