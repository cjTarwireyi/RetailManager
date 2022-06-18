using Caliburn.Micro;
using RetailManagerDesktopUI.EventModels;
using RetailManagerDesktopUI.Library.Models;
using System;

namespace RetailManagerDesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>, IHandle<LogOnEvent>
    {      
        private IEventAggregator _events;
        private SalesViewModel _salesVm;
        private readonly ILoginUserModel _user;

        public ShellViewModel( IEventAggregator events, SalesViewModel salesVm, ILoginUserModel user)
        {
            _events = events;           
            _salesVm = salesVm;
            _user = user;
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
        public void LoginOut()
        {
            _user.LogOffUser();
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsUserLoggedIn);
        }
    }
}
