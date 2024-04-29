using BarApplication.Views;
using DB_Coursework;
using DB_Coursework.Models.Users;
using System.Windows;
using System.Windows.Input;

namespace BarApplication.ViewModels.AuthVM
{
    public class AuthorizationViewModel : ObservableObject
    {
        private string _login;
        private string _password;

        public ICommand ButtonLogIn { get; }

        public AuthorizationViewModel()
        {
            ButtonLogIn = new RelayCommand(LogInCommand);
        }

        public string Login
        {
            get => _login;
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged(nameof(_login));
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(_password));
                }
            }
        }

        private void LogInCommand()
        {
            using (var context = new BarContext())
            {
                var user = context.Users.FirstOrDefault(x => x.Login == Login && x.Password == Password);
                if (user != null)
                {
                    OpenWorkWindow(user);
                }
                else
                {
                    MessageBox.Show("Wrong login or password!\nTry again or call your manager...");
                }
            }
        }

        private void OpenWorkWindow(User user)
        {
            var workWindow = new WorkWindow(user);
            workWindow.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
