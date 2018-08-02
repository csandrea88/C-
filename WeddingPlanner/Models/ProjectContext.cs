using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class WeddingPlannerContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public WeddingPlannerContext(DbContextOptions<WeddingPlannerContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<WedPlanr> Wedplanrs { get; set; }
        public DbSet<RSVP> RSVPs { get; set; }
    }
}
