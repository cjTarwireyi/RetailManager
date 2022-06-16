using RetailManagerDataManager.Library.Internal.DataAccess;
using RetailManagerDataManager.Library.Models;
using System.Collections.Generic;

namespace RetailManagerDataManager.Library.DataLayer.Product
{
    public class GetProductCollection
    {
        public List<ProductModel> GetProducts()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var result = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "DefaultConnection");

            return result;
        }
    }
}
