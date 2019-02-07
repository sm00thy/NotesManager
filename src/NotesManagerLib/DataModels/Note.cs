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
        public int UserId { get; set; }

        private Note() { }
        public Note(int id, string title, string content, int userId)
        {
            Id = id;
            Title = title;
            Content = content;
            UserId = userId;
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
