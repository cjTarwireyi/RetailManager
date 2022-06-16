using Microsoft.AspNet.Identity;
using RetailManagerDataManager.Library.DataLayer.User;
using RetailManagerDataManager.Library.Models;
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
    }
}
