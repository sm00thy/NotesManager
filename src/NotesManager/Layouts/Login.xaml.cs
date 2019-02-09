using NotesManagerLib;
using NotesManagerLib.Repositories;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NotesManager.Layouts
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly IUserRepository _userRepository = new UserRepository();
        public Login()
        {
            InitializeComponent();
        }

        private async void LoginBtnClick(object sender, RoutedEventArgs e)
        {
            var user = await _userRepository
                .GetUserAsync(loginInput.Text, passwordInput.Password);
            if (!Equals(user, null))
                NavigationService.Navigate(new NoteList(user.UserId));
            else
                MessageBox.Show("Bad credientials", "Notes Manager");
        }
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }
    }
}
