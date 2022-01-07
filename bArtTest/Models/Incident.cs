using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace bArtTest.Models
{
    public class Incident
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string name { get; set; }
        public string description { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public List<Account> accounts { get; set; }
    }
}
