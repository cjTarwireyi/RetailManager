using Microsoft.AspNet.Identity;
using RetailManagerDataManager.Library.DataLayer.Sale;
using RetailManagerDataManager.Library.Models;
using System;
using System.Web.Http;

namespace DataManagr.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
       public void Post(SaleModel sale)
        {
            CreateSaleData createSale = new CreateSaleData();
            var id = RequestContext.Principal.Identity.GetUserId();
            createSale.SaveSale(sale, id);
        }
    }
}
