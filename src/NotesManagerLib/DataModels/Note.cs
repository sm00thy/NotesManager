using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagerLib.DataModels
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get { return DateTime.Now; } } 

        private Note() { }

        public Note(int id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }

        public Note(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public override string ToString()
        {
            return Title + Content;
        }

    }
}
