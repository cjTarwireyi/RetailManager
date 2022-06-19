using RetailManagerDataManager.Library.Internal.DataAccess;
using RetailManagerDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagerDataManager.Library.DataLayer.Inventory
{
    public class InventoryRequest
    {
        public List<InventoryModel> GetInventoryCollection()
        {
            SqlDataAccess sql = new SqlDataAccess();
            return sql.LoadData<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { }, "DefaultConnection");
        }
    }
}
