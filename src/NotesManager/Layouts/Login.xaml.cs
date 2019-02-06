using NotesManagerLib.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotesManager.Layouts
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly Notedb _noteDb;
        public Login(Notedb noteDb)
        {
            _noteDb = noteDb;
        }
        public Login()
        {
            InitializeComponent();
        }

        private /* async Task */ void LoginBtnClick(object sender, RoutedEventArgs e)
        {
              ValidatePassword();
        }

        private /*async Task*/ void ValidatePassword()
        {
            if (string.IsNullOrEmpty(loginInput.Text) || string.IsNullOrEmpty(passwordInput.Password)) {
                MessageBox.Show("Login or passowrd cannot be empty", "NotesManager");
            }
            else
            {
                var user = _noteDb.Users.Where(x => x.Login == loginInput.Text).FirstOrDefault();
                if (user.Password == passwordInput.Password)
                    NavigationService.Navigate(new NoteList(user.UserId));
                else
                {
                    MessageBox.Show("Bad credientals");
                }
            }
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }
    }
}
