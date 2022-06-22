using Caliburn.Micro;
using RetailManagerDesktopUI.Library.Api;
using RetailManagerDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RetailManagerDesktopUI.ViewModels
{
    public class UserDisplayViewModel : Screen
    {
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _windowManager;
        private readonly IUserEndpoint _userEndpoint;

        BindingList<UserModel> _users;
        public BindingList<UserModel> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }
        private UserModel _selectedUser;

        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                SelectedUserName = value.Email;
                UserRoles.Clear();
                UserRoles = new BindingList<string>(value.Roles.Select(x => x.Value).ToList());
                LoadRoles();
                NotifyOfPropertyChange(() => SelectedUser);
            }
        }
        private string _selectedUserName;

        public string SelectedUserName
        {
            get { return _selectedUserName; }
            set
            {
                _selectedUserName = value;
                NotifyOfPropertyChange(() => SelectedUserName);
            }
        }
        private BindingList<string> _userRoles = new BindingList<string>();

        public BindingList<string> UserRoles
        {
            get { return _userRoles; }
            set
            {
                _userRoles = value;
                NotifyOfPropertyChange(() => UserRoles);
            }
        }

        private BindingList<string> _availableRoles = new BindingList<string>();

        public BindingList<string> AvailableRoles
        {
            get { return _availableRoles; }
            set
            {
                _availableRoles = value;
                NotifyOfPropertyChange(() => AvailableRoles);
            }
        }
        private string _selectedAvailableRole;

        public string SelectedAvailableRole
        {
            get { return _selectedAvailableRole; }
            set 
            {
                _selectedAvailableRole = value;
                NotifyOfPropertyChange(() => SelectedAvailableRole);
            }
        }
        private string _selectedUserRole;

        public string SelectedUserRole
        {
            get { return _selectedUserRole; }
            set 
            {
                _selectedUserRole = value;
                NotifyOfPropertyChange(() => SelectedUserRole);
            }
        }

        public UserDisplayViewModel(StatusInfoViewModel status, IWindowManager windowManager, IUserEndpoint userEndpoint)
        {
            _status = status;
            _windowManager = windowManager;
            _userEndpoint = userEndpoint;
        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try
            {
                await LoadUsers();
            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";
                var message = "System error contact support!";
                var messageHeading = "Error Occured";
                if (ex.Message == "Unauthorized")
                {
                    message = "You do Not have permision to interact with the sales form";
                    messageHeading = "Unauthorized Access";
                }
                _status.UpdateMessage(messageHeading, message);
                _windowManager.ShowDialog(_status, null, settings);
                TryClose();
            }
        }
        private async Task LoadUsers()
        {
            var userList = await _userEndpoint.GetAll();
            Users = new BindingList<UserModel>(userList);
        }
        private async Task LoadRoles()
        {
            var roles = await _userEndpoint.GetAllRoles();

            foreach (var role in roles)
            {
                if (UserRoles.IndexOf(role.Value) < 0)
                {
                    AvailableRoles.Add(role.Value);
                }
            }
        }
        public async Task AddSelectedRole()
        {
            await _userEndpoint.AddUserToRole(SelectedUser.Id, SelectedAvailableRole);
            UserRoles.Add(SelectedAvailableRole);
            AvailableRoles.Remove(SelectedAvailableRole);
        }
        public async Task RemoveSelectedRole()
        {
            await _userEndpoint.RemoveRole(SelectedUser.Id, SelectedUserRole);
            AvailableRoles.Add(SelectedUserRole);
            UserRoles.Remove(SelectedUserRole);
        }
    }
}
