using System.Data.Entity;

namespace NotesManagerLib.DataModels
{
    public class Notedb : DbContext
    {
        public Notedb() : base("name=DefaultConnection")
        {}

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
