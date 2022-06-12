using RetailManagerDesktopUI.Library.Models;
using RetailManagerDesktopUI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RetailManagerDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task<LoginUserModel> GetLoggedInUserInfo(string token);
        HttpClient ApiClient { get; }
    }
}