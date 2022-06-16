using RetailManagerDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace RetailManagerDesktopUI.Library.Api
{
    public interface ISaleEndPoint
    {
        Task PostSale(SaleModel sale);
    }
}