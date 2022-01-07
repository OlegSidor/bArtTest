using bArtTest.Models;
using Microsoft.EntityFrameworkCore;

namespace bArtTest.Context
{
    public class MVCContext : DbContext
    {
        public MVCContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(a => a.contacts)
                .WithOne(c => c.account)
                .HasForeignKey(c => c.Accountid);

            modelBuilder.Entity<Incident>()
                .HasMany(i => i.accounts)
                .WithOne(a => a.incident)
                .HasForeignKey(a => a.Incidentname);

            base.OnModelCreating(modelBuilder);
        }
    }

}
