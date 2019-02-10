using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagerLib.DataModels
{
    /// <summary>
    /// Class which representing User model
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id of user 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// User login 
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// User list of notes
        /// </summary>
        public List<Note> Notes { get; set; }

        private User()
        { }

        /// <summary>
        /// Two parameters constructor for creating User
        /// </summary>
        /// <param name="login">string</param>
        /// <param name="password">string </param>
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

    }
}
