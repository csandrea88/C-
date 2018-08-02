using Microsoft.EntityFrameworkCore;

namespace Belt2CSharp.Models
{
    public class Belt2CSharpContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Belt2CSharpContext(DbContextOptions<Belt2CSharpContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
