using RetailManagerDataManager.Library.DataLayer.Product;
using RetailManagerDataManager.Library.Internal.DataAccess;
using RetailManagerDataManager.Library.Models;
using RetailManagerDesktopUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RetailManagerDataManager.Library.DataLayer.Sale
{
    public class CreateSaleData
    {
        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            GetSingleProduct productDbTable = new GetSingleProduct();
            var vat = ConfigHelperExt.GetTaxRate();
            var saleDetails = new List<SaleDetailDbModel>();
            foreach (var item in saleInfo.SaleDetails)
            {
                var saleDetail = new SaleDetailDbModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };

                var productInfo = productDbTable.GetProductById(item.ProductId);
                if(productInfo == null)
                {
                    throw new Exception($"The product Id of {item.ProductId} could not be found in the database");
                }

                saleDetail.PurchasePrice = (productInfo.RetailPrice * saleDetail.Quantity);
                if (productInfo.IsTaxable)
                {
                    saleDetail.Tax = (saleDetail.PurchasePrice * vat);
                }
                saleDetails.Add(saleDetail);
            }
            SaleDbModel sale = new SaleDbModel 
            {
                SubTotal = saleDetails.Sum(x => x.PurchasePrice),
                Tax = saleDetails.Sum(x => x.Tax),
                CashierId = cashierId
            };

            sale.Total = sale.SubTotal + sale.Tax;

            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spSale_Insert", sale, "DefaultConnection");

            var saleId =sql.LoadData<int, dynamic>("dbo.spSale_GetByExpression", new { sale.CashierId, sale.SaleDate }, "DefaultConnection").FirstOrDefault();
            foreach (var item in saleDetails)
            {
                item.SaleId = saleId;
                sql.SaveData("dbo.spSaleDetail_Insert", item, "DefaultConnection");
                sql.SaveData("dbo.spProduct_Update", new { item.ProductId, PurchasedQuantity = item.Quantity }, "DefaultConnection");
            }
              
        }
    }
}
