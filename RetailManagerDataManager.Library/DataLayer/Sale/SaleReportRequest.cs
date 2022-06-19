using RetailManagerDataManager.Library.Internal.DataAccess;
using RetailManagerDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagerDataManager.Library.DataLayer.Sale
{
    public class SaleReportRequest
    {
        public List<SaleReportModel> GetSaleReportCollection()
        {
            SqlDataAccess sql = new SqlDataAccess();
            return sql.LoadData<SaleReportModel, dynamic>("dbo.spSale_Report", new { }, "DefaultConnection");
        }
    }
}
