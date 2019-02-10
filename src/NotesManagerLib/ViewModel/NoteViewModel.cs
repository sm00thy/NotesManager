using NotesManagerLib.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagerLib.ViewModel
{
    /// <summary>
    /// Class which getting all notes for given user 
    /// </summary>
    public class NoteViewModel
    {
        readonly NoteDb noteDb = new NoteDb();

        /// <summary>
        /// Getting all notes for user of given Id
        /// </summary>
        /// <param name="userId">int Id of user</param>
        public NoteViewModel(int userId)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            Notes = noteDb.Notes.Where(x => x.UserId == userId).ToList();
        }

        /// <summary>
        /// List of user notes
        /// </summary>
        public IList<Note> Notes { get; set; }
    }
}
