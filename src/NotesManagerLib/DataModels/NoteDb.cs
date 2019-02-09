using System.Data.Entity;

namespace NotesManagerLib.DataModels
{
    /// <summary>
    /// Database init & tables set
    /// </summary>
    public class NoteDb : DbContext
    {
        public NoteDb() : base("name=DefaultConnection")
        {}

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
