using Microsoft.AspNet.Identity;
using RetailManagerDataManager.Library.DataLayer.Sale;
using RetailManagerDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace DataManagr.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
       public void Post(SaleModel sale)
        {
            CreateSaleCommand createSale = new CreateSaleCommand();
            var id = RequestContext.Principal.Identity.GetUserId();
            createSale.Add(sale, id);
        }
        [Route("GetSalesReport")]
        public List<SaleReportModel> GetSalesReport()
        {
            SaleReportRequest saleReportRequest = new SaleReportRequest();
            return saleReportRequest.GetSaleReportCollection();
        }
    }
}
