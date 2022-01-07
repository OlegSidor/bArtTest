using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace bArtTest.Models
{
    [Index(nameof(Account.name), IsUnique = true)]

    public class Account
    {

        public int id { get; set; }

        [Required]
        public string name { get; set; }
        public List<Contact> contacts { get; set; } = new List<Contact>();

    }
}
