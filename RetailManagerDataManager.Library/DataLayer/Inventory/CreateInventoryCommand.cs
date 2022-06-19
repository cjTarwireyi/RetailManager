using RetailManagerDataManager.Library.Internal.DataAccess;
using RetailManagerDataManager.Library.Models;

namespace RetailManagerDataManager.Library.DataLayer.Inventory
{
    public class CreateInventoryCommand
    {
        public void Add(InventoryModel item)
        {
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spInventory_Insert", item, "DefaultConnection");
        }
    }
}
