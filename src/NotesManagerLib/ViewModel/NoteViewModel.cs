using NotesManagerLib.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagerLib.ViewModel
{
    public class NoteViewModel
    {
        readonly Notedb noteDb = new Notedb();
        public NoteViewModel()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            Notes = noteDb.Notes.ToList();
        }

        public IList<Note> Notes { get; set; }
    }
}
