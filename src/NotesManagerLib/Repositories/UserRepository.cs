using NotesManagerLib.DataModels;
using NotesManagerLib.Repositories;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NotesManagerLib
{
    public class UserRepository : IUserRepository
    {
        private NoteDb _noteDb = new NoteDb();
        public UserRepository()
        { }

        public async Task<bool> ValidateInput(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return false;
            else
            {
                var user = await GetUserAsync(login, password);
                if (user == null)
                    return false;
                else
                    return true;
            }
        }

        public async Task<User> GetUserAsync(string login, string password)
        {
                var user = await _noteDb.Users
                        .Where(x => x.Login == login &&
                        x.Password == password).SingleOrDefaultAsync();
                return user;
        }

        public async Task AddUserAsync(string login, string password)
        {
            var checkIfUserExist = await GetUserAsync(login, password);
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                MessageBox.Show("Login or passowrd cannot be empty", "Notes Manager");
            else if (login.Length < 2)
                MessageBox.Show("Login is too short", "Notes Manager");
            else if (password.Length < 5)
                MessageBox.Show("Password length must be above 5 characters", "Notes Manager");
            else if (!Equals(checkIfUserExist, null))
                MessageBox.Show("User already exist!", "Notes Manager");
            else
            {
                var user = new User(login, password);
                _noteDb.Users.Add(user);
                await _noteDb.SaveChangesAsync();
                MessageBox.Show("Register succesful", "NotesManager");
            }
        }
    }
}
