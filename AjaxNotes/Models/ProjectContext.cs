using Microsoft.EntityFrameworkCore;

namespace AjaxNotes.Models
{
    public class AjaxNotesContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public AjaxNotesContext(DbContextOptions<AjaxNotesContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ANote> Anotes { get; set; }
    }
}
