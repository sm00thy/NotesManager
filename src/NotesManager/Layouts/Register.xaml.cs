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
            ValidatePassword();
        }

        private void ValidatePassword()
        {
            if (string.IsNullOrEmpty(loginInput.Text) || string.IsNullOrEmpty(passwordInput.Password))
                MessageBox.Show("Login or passowrd cannot be empty", "Notes Manager");
            else if (loginInput.Text.Length < 2)
                MessageBox.Show("Login is too short", "Notes Manager");
            else if (passwordInput.Password.Length < 5)
                MessageBox.Show("Password length must be above 5 characters", "Notes Manager");
            else
            {
                MessageBox.Show("Register succesful", "NotesManager");
                NavigationService.GoBack();
            }
        }
    }
}
