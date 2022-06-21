using DataManagr.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RetailManagerDataManager.Library.DataLayer.User;
using RetailManagerDataManager.Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DataManagr.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
       
        public UserModel GetById()
        {
            GetSingleUser data = new GetSingleUser();

            var id = RequestContext.Principal.Identity.GetUserId();

            return data.GetUserById(id);
        }
        [Authorize(Roles = "Admin")]
        [Route("api/User/Admin/GetAllUsers")]
        public List<ApplicationUserModel> GetAllUsers()
        {
            var output = new List<ApplicationUserModel>();
            using (var context = new ApplicationDbContext())
            {                
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var users = userManager.Users.ToList();

                var roles = context.Roles.ToList(); 
                foreach(var user in users)
                {
                    ApplicationUserModel userModel = new ApplicationUserModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                    };
                 
                    foreach (var userRole in user.Roles)
                    {
                        userModel.Roles.Add(userRole.RoleId, roles.First(x => x.Id == userRole.RoleId).Name);
                    }
                    output.Add(userModel);
                }
            }
            return output;

        }
    }
}
