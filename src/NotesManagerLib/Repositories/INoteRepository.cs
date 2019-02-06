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
        Task<IEnumerable<Note>> GetAllByUserIdAsync(int userId);

        Task RemoveAsync(Note note);
    }
}
