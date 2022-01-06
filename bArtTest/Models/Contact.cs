using System.ComponentModel.DataAnnotations;

namespace bArtTest.Models
{
    public class Contact
    {
        [Key]
        public int id { get; set; }
        public string firts_name { get; set; }
        public string last_name { get; set; }

        [Required]
        public string email { get; set; }
    }
}
