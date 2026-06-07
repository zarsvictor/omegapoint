using Microsoft.EntityFrameworkCore;

namespace Omegapoint_uppgift.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } = null!;

        public PersonContext(DbContextOptions<PersonContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
        }
    }
}
