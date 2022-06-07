using Microsoft.AspNet.Identity;
using RetailManagerDataManager.Library.DataAccess;
using RetailManagerDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace DataManagr.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
       
        public List<UserModel> GetById()
        {
            UserData data = new UserData();

            var id = RequestContext.Principal.Identity.GetUserId();

            var collection = data.GetUserById(id);   

            return collection;
        }
    }
}
