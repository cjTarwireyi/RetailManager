using RetailManagerDataManager.Library.Internal.DataAccess;
using RetailManagerDataManager.Library.Models;
using System.Collections.Generic;

namespace RetailManagerDataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetProducts()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var result = sql.LoadData<ProductModel, dynamic>("dbo.spProductGetAll", new { }, "DefaultConnection");

            return result;
        }
    }
}
