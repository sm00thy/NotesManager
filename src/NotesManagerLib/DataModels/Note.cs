using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagerLib.DataModels
{
    /// <summary>
    /// Class which representing Note model
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Note id 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Note title string
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Note content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Date
        /// </summary>
        public DateTime DateTime { get { return DateTime.Now; } } 
        /// <summary>
        /// Id of user who add note
        /// </summary>
        public int UserId { get; set; }

        private Note() { }

        /// <summary>
        /// Four parameters constructor for creating Note
        /// </summary>
        /// <param name="id">int noteId</param>
        /// <param name="title">string </param>
        /// <param name="content">string </param>
        /// <param name="userId">int Id of user who creating Note</param>
        public Note(int id, string title, string content, int userId)
        {
            Id = id;
            Title = title;
            Content = content;
            UserId = userId;
        }

        /// <summary>
        /// Two parameters constructor for creating Note
        /// </summary>
        /// <param name="title">string</param>
        /// <param name="content">string</param>
        public Note(string title, string content)
        {
            Title = title;
            Content = content;
        }

        /// <summary>
        /// Text reprezentation of note
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Title + Content;
        }

    }
}
