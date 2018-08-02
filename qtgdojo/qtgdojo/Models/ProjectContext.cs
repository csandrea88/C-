using Microsoft.EntityFrameworkCore;

namespace qtgdojo.Models
{
    public class QtgdojoContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public QtgdojoContext(DbContextOptions<QtgdojoContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Qtg> Qtgs { get; set; }
    }
}
