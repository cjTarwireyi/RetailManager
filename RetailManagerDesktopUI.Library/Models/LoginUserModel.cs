using System;

namespace RetailManagerDesktopUI.Library.Models
{
    public class LoginUserModel : ILoginUserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Token { get; set; }
        public void ResetUserModel()
        {
            Token = null;
            FirstName  = null;  
            LastName = null;    
            EmailAdress = null;
            CreatedDate = DateTime.MinValue;
        }
    }
}
