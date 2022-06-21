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
    public class UserDisplayViewModel: Screen
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
    }
}
