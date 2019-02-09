using NotesManagerLib;
using NotesManagerLib.Repositories;
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
        private readonly IUserRepository _userRepository = new UserRepository();
        public Register()
        {
            InitializeComponent();
        }

        private async void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            await _userRepository.AddUserAsync(loginInput.Text, passwordInput.Password);
            bool check = await _userRepository
                .ValidateInput(loginInput.Text, passwordInput.Password);
            if (check)
                NavigationService.GoBack();
        }
    }
}