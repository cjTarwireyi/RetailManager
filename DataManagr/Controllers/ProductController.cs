using RetailManagerDataManager.Library.DataLayer.Product;
using RetailManagerDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace DataManagr.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        public List<ProductModel> Get()
        {
            ProductsRequest data = new ProductsRequest();
            return data.GetProductCollection();
        }
    }
}
