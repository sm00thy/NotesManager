using NotesManagerLib.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagerLib.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ValidateInput(string login, string password);
        Task<User> GetUserAsync(string login, string password);
        Task AddUserAsync(string login, string password);
    }
}
