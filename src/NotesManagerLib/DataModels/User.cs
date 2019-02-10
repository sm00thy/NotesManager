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
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
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
