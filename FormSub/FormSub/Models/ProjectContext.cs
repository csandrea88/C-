using Microsoft.EntityFrameworkCore;

namespace FormSub.Models
{
    public class FormSubContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public FormSubContext(DbContextOptions<FormSubContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Form> Forms { get; set; }
    }
}
