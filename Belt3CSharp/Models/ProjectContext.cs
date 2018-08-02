using Microsoft.EntityFrameworkCore;

namespace Belt3CSharp.Models
{
    public class Belt3CSharpContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Belt3CSharpContext(DbContextOptions<Belt3CSharpContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Belt3> Belt3s { get; set; }
        public DbSet<MtoM> MtoMs { get; set; }
    }
}
