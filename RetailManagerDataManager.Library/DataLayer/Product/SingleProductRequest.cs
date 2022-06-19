using RetailManagerDataManager.Library.Internal.DataAccess;
using RetailManagerDataManager.Library.Models;
using System.Linq;

namespace RetailManagerDataManager.Library.DataLayer.Product
{
    public class SingleProductRequest
    {
        public ProductModel GetProductById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = id };

            return sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetById", p, "DefaultConnection").FirstOrDefault();
        }
    }
}
