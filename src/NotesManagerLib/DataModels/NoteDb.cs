using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagerLib.DataModels
{
    public class NoteDb : DbContext
    {
        public NoteDb() : base("name=DefaultConnection")
        {}

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
