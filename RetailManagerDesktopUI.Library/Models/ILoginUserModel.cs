using System;

namespace RetailManagerDesktopUI.Library.Models
{
    public interface ILoginUserModel
    {
        DateTime CreatedDate { get; set; }
        string EmailAdress { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
        string Token { get; set; }
        void ResetUserModel();
    }
}