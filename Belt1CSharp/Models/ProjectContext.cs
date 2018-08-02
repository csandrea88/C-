using Microsoft.EntityFrameworkCore;

namespace Belt1CSharp.Models
{
    public class Belt1CSharpContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Belt1CSharpContext(DbContextOptions<Belt1CSharpContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities{ get; set; }
        public DbSet<Participant> Participants {get; set;}
    }
}
