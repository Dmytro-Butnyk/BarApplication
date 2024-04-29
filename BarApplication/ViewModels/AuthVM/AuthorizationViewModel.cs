using BarApplication.Views;
using DB_Coursework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            get { return _login; }
            set { _login = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private void LogInCommand()
        {
            using (BarContext context = new())
            {
                var logInObject = context.Users
                    .FirstOrDefault(x => x.Login == _login
                    && x.Password == _password);
                if(logInObject != null)
                {
                    var workWindow = new WorkWindow(logInObject);
                    workWindow.Show();
                    Application.Current.MainWindow.Close();
                }
                else
                {
                    MessageBox.Show("Wrong login or password!\nTry again or call your manager...");
                }
            }
        }
    }
}
