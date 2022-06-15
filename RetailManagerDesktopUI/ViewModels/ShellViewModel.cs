using Caliburn.Micro;
using RetailManagerDesktopUI.EventModels;
using System;

namespace RetailManagerDesktopUI.ViewModels
{
    public class ShellViewModel: Conductor<object>, IHandle<LogOnEvent>
    {      
        private IEventAggregator _events;
        private SalesViewModel _salesVm;
        public ShellViewModel( IEventAggregator events, SalesViewModel salesVm, SimpleContainer container)
        {
            _events = events;           
            _salesVm = salesVm;

            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());            
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVm);
        }
    }
}
