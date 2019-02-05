using NotesManagerLib.DataModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NotesManager.Layouts
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            RegisterUser();
        }

        private async void RegisterUser()
        {
            var _dbContext = new NoteDb();
            
            if (string.IsNullOrEmpty(loginInput.Text) || string.IsNullOrEmpty(passwordInput.Password))
                MessageBox.Show("Login or passowrd cannot be empty", "Notes Manager");
            else if (loginInput.Text.Length < 2)
                MessageBox.Show("Login is too short", "Notes Manager");
            else if (passwordInput.Password.Length < 5)
                MessageBox.Show("Password length must be above 5 characters", "Notes Manager");
            else
            {
                var user = new User(loginInput.Text, passwordInput.Password);
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                MessageBox.Show("Register succesful", "NotesManager");
                NavigationService.GoBack();
            }
        }
    }
}
