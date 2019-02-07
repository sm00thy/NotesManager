using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesManagerLib.DataModels;

namespace NotesManagerLib.Repositories
{
    class NoteRepository : INoteRepository
    {
        private readonly Notedb _noteDbContext;

        public NoteRepository(Notedb noteDb)
        {
            _noteDbContext = noteDb;
        }

        public async Task AddAsync(Note note)
        {
            _noteDbContext.Notes.Add(note);
            await _noteDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Note>> GetAllByUserIdAsync(int userId)
        {
            var notes = await _noteDbContext.Notes
                        .Where(x => x.UserId == userId)
                        .ToListAsync();
            return notes;
        }

        public async Task RemoveAsync(Note note)
        {
            _noteDbContext.Notes.Remove(note);
            await _noteDbContext.SaveChangesAsync();
        }
    }
}
