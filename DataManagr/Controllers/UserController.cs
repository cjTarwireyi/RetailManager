using Microsoft.AspNet.Identity;
using RetailManagerDataManager.Library.DataAccess;
using RetailManagerDataManager.Library.Models;
using System.Linq;
using System.Web.Http;

namespace DataManagr.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
       
        public UserModel GetById()
        {
            UserData data = new UserData();

            var id = RequestContext.Principal.Identity.GetUserId();

            var collection = data.GetUserById(id).FirstOrDefault();   

            return collection;
        }
    }
}
