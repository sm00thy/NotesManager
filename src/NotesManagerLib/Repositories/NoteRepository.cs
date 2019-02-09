using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesManagerLib.DataModels;
using NotesManagerLib.ViewModel;

namespace NotesManagerLib.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private NoteDb _noteDb = new NoteDb();
        public NoteRepository()
        {}

        public async Task AddAsync(Note note)
        {
            _noteDb.Notes.Add(note);
            await _noteDb.SaveChangesAsync();
        }

        public async Task<Note> GetNoteAsync(int noteId)
        {
           return await _noteDb.Notes.
                SingleOrDefaultAsync(x => x.Id == noteId);
        }

        public async Task RemoveAsync(Note note)
        {
            _noteDb.Notes.Remove(note);
            await _noteDb.SaveChangesAsync();
        }

        public async Task UpdateAsync(Note note)
        {
            var temp = await _noteDb.Notes
                .SingleOrDefaultAsync(x => x.Id == note.Id);
            temp.Title = note.Title;
            temp.Content = note.Content;
            await _noteDb.SaveChangesAsync();
        }
    }
}
