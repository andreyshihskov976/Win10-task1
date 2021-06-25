using System.Windows;
using System.Windows.Controls;
using Win10_task1.ViewModels;

namespace Win10_task1.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationForm.xaml
    /// </summary>
    public partial class LoginForm : UserControl
    {
        public LoginForm()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            LoginBox.Clear();
            PasswordBox.Password = string.Empty;
        }
    }
}
