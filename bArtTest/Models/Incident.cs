using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bArtTest.Models
{
    public class Incident
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string name { get; set; }
        public string description { get; set; }
        public List<Account> accounts { get; set; }
    }
}
