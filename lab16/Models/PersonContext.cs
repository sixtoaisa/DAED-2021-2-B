using Microsoft.EntityFrameworkCore;

namespace lab16.Models
{
    public class PersonContext: DbContext
    {

        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }

    }
}
