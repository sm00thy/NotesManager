using NotesManagerLib.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagerLib.Repositories
{
    public interface INoteRepository
    {
        Task<Note> GetNoteAsync(int noteId);
        Task AddAsync(Note note);
        Task RemoveAsync(Note note);
        Task UpdateAsync(Note note);
    }
}
