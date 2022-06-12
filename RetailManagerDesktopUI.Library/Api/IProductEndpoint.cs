using RetailManagerDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailManagerDesktopUI.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}