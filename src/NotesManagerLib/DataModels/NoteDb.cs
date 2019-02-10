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

        /// <summary>
        /// Notes table in db
        /// </summary>
        public DbSet<Note> Notes { get; set; }
        /// <summary>
        /// Users table in db 
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
