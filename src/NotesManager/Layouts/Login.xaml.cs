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
        public Login()
        {
            InitializeComponent();
        }

        private /*async*/ void LoginBtnClick(object sender, RoutedEventArgs e)
        {
              ValidatePassword();
        }

        private /*async Task*/ void ValidatePassword()
        {
            var notedb = new Notedb();
            if (string.IsNullOrEmpty(loginInput.Text) || string.IsNullOrEmpty(passwordInput.Password)) {
                MessageBox.Show("Login or passowrd cannot be empty", "NotesManager");
            }
            else
            {
                var user = notedb.Users
                    .Where(x => x.Login == loginInput.Text && 
                    x.Password == passwordInput.Password).FirstOrDefault();

                if (user == null)
                    MessageBox.Show("Bad credientals");
                else
                    NavigationService.Navigate(new NoteList(user.UserId));
            }
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }
    }
}
