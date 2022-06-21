using Caliburn.Micro;
using RetailManagerDesktopUI.EventModels;
using RetailManagerDesktopUI.Library.Api;
using RetailManagerDesktopUI.Library.Models;
using System;

namespace RetailManagerDesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>, IHandle<LogOnEvent>
    {      
        private IEventAggregator _events;
        private SalesViewModel _salesVm;
        private readonly ILoginUserModel _user;
        private readonly IAPIHelper _apiHelper;

        public ShellViewModel( IEventAggregator events, SalesViewModel salesVm, ILoginUserModel user, IAPIHelper apiHelper)
        {
            _events = events;           
            _salesVm = salesVm;
            _user = user;
            _apiHelper = apiHelper;
            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());            
        }
        public bool IsUserLoggedIn
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_user.Token);
            }

        }
        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVm);
            NotifyOfPropertyChange(() => IsUserLoggedIn);
        }
        public void ExitApplication()
        {
            TryClose();
        }
        public void LogOut()
        {

            _apiHelper.ClearLoginUserData();
            _user.ResetUserModel();
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsUserLoggedIn);
        }
        public void UserManagement()
        {
            ActivateItem(IoC.Get<UserDisplayViewModel>());
        }
    }
}
