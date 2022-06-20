using Caliburn.Micro;

namespace RetailManagerDesktopUI.ViewModels
{
    public class StatusInfoViewModel: Screen
    {
        public string Header { get; private set; }
        public string Message { get; private set; }

        public void UpdateMessage(string header, string message)
        {
            Message = message;  
            Header = header;

            NotifyOfPropertyChange(() => Header);
            NotifyOfPropertyChange(() => Message);
        }
        public void close()
        {
            TryClose();
        }
    }
}
