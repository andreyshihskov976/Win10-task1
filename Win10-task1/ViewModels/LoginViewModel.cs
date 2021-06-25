using System.Windows;
using System.Windows.Input;
using Win10_task1.Exceptions;
using Win10_task1.Models;
using Win10_task1.Services.AuthentificationServices;
using Win10_task1.ViewModels.Commands;
using Win10_task1.Views;

namespace Win10_task1.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        protected IAuthentificationService _authentificationService;

        private string _login;

        public string Login
        {
            get { return _login; }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged(nameof(Login));
                }
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public LoginViewModel()
        {
            _authentificationService = new AuthentificationService();
            LogInCommand = new DelegateCommand(LogIn);
            RegisterCommand = new DelegateCommand(Register);
        }

        private void Register(object obj)
        {
            Application.Current.MainWindow.Content = new RegistrationViewModel();
        }

        private async void LogIn(object obj)
        {
            try
            {
                User loggedInUser = await _authentificationService.Login(Login, Password);
                Application.Current.MainWindow.Content = new MainWorkspace(new MainWorkspaceViewModel(loggedInUser));
            }
            catch (AuthentificationException exception)
            {
                MessageBox.Show($"{exception.Message}\nЛогин: {exception.Login}\nПароль: {exception.Password}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ICommand LogInCommand { get; private set; }

        public ICommand RegisterCommand { get; private set; }
    }
}
