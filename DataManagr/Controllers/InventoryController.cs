using RetailManagerDataManager.Library.DataLayer.Inventory;
using RetailManagerDataManager.Library.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace DataManagr.Controllers
{
    [Authorize]
    public class InventoryController : ApiController
    {
        [Authorize(Roles = "Admin")]
        public void Post(InventoryModel sale)
        {
            CreateInventoryCommand createInventoryCommand = new CreateInventoryCommand();
            createInventoryCommand.Add(sale);
        }

        [Authorize(Roles = "Admin,Manager")]
        [Route("GetInventoryCollection")]
        public List<InventoryModel> GetInventoryCollection()
        {
            InventoryRequest inventoryRequest = new InventoryRequest();
            return inventoryRequest.GetInventoryCollection();
        }

    }
}
