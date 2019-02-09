using NotesManagerLib.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagerLib.ViewModel
{
    public class NoteViewModel
    {
        readonly NoteDb noteDb = new NoteDb();
        public NoteViewModel(int userId)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            Notes = noteDb.Notes.Where(x => x.UserId == userId).ToList();
        }

        public IList<Note> Notes { get; set; }
    }
}
