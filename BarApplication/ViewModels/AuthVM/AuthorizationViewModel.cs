﻿using BarApplication.Views;
using DB_Coursework;
using DB_Coursework.Models.Users;
using System.Net;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace BarApplication.ViewModels.AuthVM
{
    public class AuthorizationViewModel : ObservableObject
    {
        private string _login;
        private SecureString _password;



        public ICommand ButtonLogIn { get; }

        public AuthorizationViewModel()
        {
            ButtonLogIn = new RelayCommand(LogInCommand);
            CheckForEmptyUsers();
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

        public SecureString Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private void LogInCommand()
        {
            using (var context = new BarContext())
            {

                var password = new NetworkCredential(string.Empty, Password).Password;
                var user = context.Users.FirstOrDefault(x => x.Login == Login && x.Password == password);
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
            new WorkWindow(user).Show();
        }
        private SecureString ToSecureString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input string cannot be empty.", nameof(input));

            var secureString = new SecureString();
            foreach (char c in input)
            {
                secureString.AppendChar(c);
            }
            secureString.MakeReadOnly();
            return secureString;
        }
        private void CheckForEmptyUsers()
        {
            using (BarContext context = new())
                if (context.Users.ToList().Count == 0)
                {
                    context.Add(new User("admin", "admin", "Manager"));
                    context.SaveChanges();
                    Login = "admin";
                    Password = ToSecureString("admin");
                    MessageBox.Show("Programm launched at first time\n" +
                        "Manager account data:\n" +
                        "Login: admin\n" +
                        "Password: admin\n" +
                        "You can add new managers or sellers after authorization.");
                }
        }
    }

}
