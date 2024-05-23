using DB_Coursework;
using DB_Coursework.Models.Users;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace BarApplication.ViewModels.ManVM
{
    public class ManagerUsersViewModel : ObservableObject
    {
        private readonly BarContext _context = new();
        private readonly User _activeUser;
        private List<User> _users;
        private User _selectedUser;

        public ICommand DeleteUserCommand { get; }
        public ICommand AddUserCommand { get; }
        public ICommand ShowAddFieldsCommand { get; }

        private string _nLogin;
        private string _nPassword;
        private string _nPosition;
        private Visibility _addFieldsVisibility = Visibility.Collapsed;

        public ICommand GoToSuppliesCommand { get; }
        public ICommand GoToProductsCommand {  get; }
        public ICommand GoToAuthorization { get; }

        public ManagerUsersViewModel(NavigationDataServiceMan nbvm)
        {
            _activeUser = nbvm.ActiveUser;

            GoToSuppliesCommand = nbvm.GoToSuppliesPageCommand;
            GoToProductsCommand = nbvm.GoToProductsPageCommand;
            GoToAuthorization = nbvm.GoToAuthorizationWindowCommand;

            var usersRefreshTimer = new DispatcherTimer();
            usersRefreshTimer.Tick += async (sender, e) => await LoadUsers();
            usersRefreshTimer.Interval = TimeSpan.FromSeconds(1);
            usersRefreshTimer.Start();

            Timer userInfoRefreshTimer = new
                (async (state) => await UserRefreshInformation(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(1));

            DeleteUserCommand = new RelayCommand(async () => await DeleteUserAsync());
            AddUserCommand = new RelayCommand(async () => await AddUserAsync());
            ShowAddFieldsCommand = new RelayCommand(ShowAddFieldsAsync);
        }

        public List<string> NPositions => new List<string> { "Seller", "Manager" };

        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
                UserRefreshInformation();
            }
        }

        public List<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public string NLogin
        {
            get => _nLogin;
            set
            {
                _nLogin = value;
                OnPropertyChanged(nameof(NLogin));
            }
        }

        public string NPassword
        {
            get => _nPassword;
            set
            {
                _nPassword = value;
                OnPropertyChanged(nameof(NPassword));
            }
        }

        public string NPosition
        {
            get => _nPosition;
            set
            {
                _nPosition = value;
                OnPropertyChanged(nameof(NPosition));
            }
        }

        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Position { get; private set; }

        public Visibility AddFieldsVisibility
        {
            get => _addFieldsVisibility;
            set
            {
                _addFieldsVisibility = value;
                OnPropertyChanged(nameof(AddFieldsVisibility));
            }
        }

        private async Task LoadUsers()
        {
            Users = _context.Users.ToList();
        }

        private async Task UserRefreshInformation()
        {
            if (SelectedUser != null)
            {
                Login = SelectedUser.Login;
                Password = SelectedUser.Password;
                Position = SelectedUser.Position;
                OnPropertyChanged(nameof(Login));
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(Position));
            }
        }

        private async Task DeleteUserAsync()
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("Choose user to delete!");
                return;
            }
            if (SelectedUser.Login == _activeUser.Login)
            {
                MessageBox.Show("You cannot delete yourself!");
            }
            else if (_activeUser == null)
            {
                MessageBox.Show("Select user to delete");
            }
            else
            {
                _context.Remove(SelectedUser);
                _context.SaveChanges();
                MessageBox.Show($"User: {SelectedUser.Login} deleted.");
            }
        }

        private async Task AddUserAsync()
        {
            if (string.IsNullOrWhiteSpace(NLogin) || string.IsNullOrWhiteSpace(NPassword) || string.IsNullOrWhiteSpace(NPosition))
            {
                MessageBox.Show("Please fill all the fields!");
                return;
            }

            if (_context.Users.Any(x => x.Login == NLogin))
            {
                MessageBox.Show("User exists!");
                return;
            }

            _context.Add(new User(NLogin, NPassword, NPosition));
            _context.SaveChanges();
            MessageBox.Show("User successfully added.");
            EreaseAddFields();
        }

        private void EreaseAddFields()
        {
            NLogin = "";
            NPassword = "";
            NPosition = null;
        }

        private void ShowAddFieldsAsync()
        {
            AddFieldsVisibility = AddFieldsVisibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
