using RetailManagerDataManager.Library.Internal.DataAccess;
using RetailManagerDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagerDataManager.Library.DataLayer.User
{
    public class GetSingleUser
    {
        public UserModel GetUserById(string id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = id };

           return sql.LoadData<UserModel, dynamic>("dbo.spUser_GetById", p, "DefaultConnection").FirstOrDefault();
        }
    }
}
