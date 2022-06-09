using Caliburn.Micro;
using RetailManagerDesktopUI.Library.Api;
using System;
using System.Threading.Tasks;

namespace RetailManagerDesktopUI.ViewModels
{

    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        private IAPIHelper _apiHelper;
        private bool _isErrorVisible;
        private string _errorMessage;
        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool IsErrorVisible 
        {
            get 
            {
                return ErrorMessage?.Length > 0;
            }
            
        }

        public string ErrorMessage 
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }
        public bool CanLogIn
        {
            get
            {
                bool output = false;
                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
        }

        public async Task LogIn()
        {
            try
            {
              ErrorMessage = string.Empty;
              var result = await _apiHelper.Authenticate(UserName, Password);

              await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
    }
}
