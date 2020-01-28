using Microsoft.EntityFrameworkCore;
namespace DotNetNotesApi.Models
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) : base(options)
        {
        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteType> NoteTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteType>()
                .ToTable("NoteType");

            modelBuilder.Entity<NoteType>()
                .HasData(
                    new NoteType
                    {
                        Id = 1,
                        Name = "Reminder"
                    },
                    new NoteType
                    {
                        Id = 2,
                        Name = "ToDo"
                    }
                );
        }

    }
}