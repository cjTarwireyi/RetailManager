using Microsoft.AspNet.Identity;
using RetailManagerDataManager.Library.DataAccess;
using RetailManagerDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace DataManagr.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        // GET api/values
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData();
            return data.GetProducts();
        }
    }
}
