using RetailManagerDataManager.Library.Internal.DataAccess;
using RetailManagerDataManager.Library.Models;
using System.Collections.Generic;

namespace RetailManagerDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = id };

           var result = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "DefaultConnection");

            return result;
        }
    }
}
