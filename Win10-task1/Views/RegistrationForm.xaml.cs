using System.Windows;
using System.Windows.Controls;
using Win10_task1.ViewModels;

namespace Win10_task1.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : UserControl
    {
        public RegistrationForm()
        {
            InitializeComponent();
            DataContext = new RegistrationViewModel();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            LastNameBox.Clear();
            FirstNameBox.Clear();
            SurNameBox.Clear();
            LoginBox.Clear();
            PasswordBox.Clear();
        }
    }
}
