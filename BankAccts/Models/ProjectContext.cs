using Microsoft.EntityFrameworkCore;

namespace BankAccts.Models
{
    public class BankAcctsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BankAcctsContext(DbContextOptions<BankAcctsContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<BAcc> BAccs { get; set; }
    }
}
