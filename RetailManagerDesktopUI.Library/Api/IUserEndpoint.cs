using RetailManagerDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailManagerDesktopUI.Library.Api
{
    public interface IUserEndpoint
    {
        Task<List<UserModel>> GetAll();
        Task<Dictionary<string, string>> GetAllRoles();
        Task RemoveRole(string userId, string roleName);
        Task AddUserToRole(string userId, string roleName);
    }
}