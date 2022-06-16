using System.Collections.Generic;

namespace RetailManagerDesktopUI.Library.Models
{
    public class SaleModel
    {
        public List<SaleDetailModel> SaleDetails { get; set; } = new List<SaleDetailModel> ();
    }
}
