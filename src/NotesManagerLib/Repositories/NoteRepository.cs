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
    /// <summary>
    /// Class NoteRepository for communication with db
    /// </summary>
    public class NoteRepository : INoteRepository
    {
        private NoteDb _noteDb = new NoteDb();

        public NoteRepository()
        {}

        /// <summary>
        /// Adding note to db
        /// </summary>
        /// <param name="note">adding entity</param>
        /// <returns>Id of added entity</returns>
        public async Task<int> AddAsync(Note note)
        {
            _noteDb.Notes.Add(note);
            await _noteDb.SaveChangesAsync();
            return note.Id;
        }

        /// <summary>
        /// Getting entity from db by Id
        /// </summary>
        /// <param name="noteId">int Id of entity to get</param>
        /// <returns>Entity </returns>
        public async Task<Note> GetNoteAsync(int noteId)
        {
           return await _noteDb.Notes.
                SingleOrDefaultAsync(x => x.Id == noteId);
        }

        /// <summary>
        /// Removing entity from db
        /// </summary>
        /// <param name="note">Entity which will be removed</param>
        public async Task RemoveAsync(Note note)
        {
            _noteDb.Notes.Remove(note);
            await _noteDb.SaveChangesAsync();
        }

        /// <summary>
        /// Updating entity 
        /// </summary>
        /// <param name="note">Entoty to update</param>
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
